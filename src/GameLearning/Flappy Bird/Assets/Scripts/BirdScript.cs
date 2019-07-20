using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public static BirdScript instance;
    public bool isAlive;

    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Animator anim;
    private Button flapButton;

    private float fowardSpeed = 3f;
    private float bounceSpeed = 4f;
    private bool didFlap;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isAlive = true;

        //add fuction for button
        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        flapButton.onClick.AddListener(() => FlapTheBird());

        SetCameraX();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            //current position of the bird
            Vector3 temp = transform.position;
            temp.x += fowardSpeed * Time.deltaTime;
            transform.position = temp;

            if (didFlap)
            {
                didFlap = false;
                rigidbody.velocity = new Vector2(0, bounceSpeed);
                //trigger flap animation
                anim.SetTrigger("Flap");
            }

            if (rigidbody.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -rigidbody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    void SetCameraX()
    {
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }
}
