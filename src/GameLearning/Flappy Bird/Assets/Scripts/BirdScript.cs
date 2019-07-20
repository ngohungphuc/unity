using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private static BirdScript instance;
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Animator anim;
    private float fowardSpeed = 3f;
    private float bounceSpeed = 4f;
    private bool didFlap;
    public bool isAlive;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isAlive = true;
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

            if(didFlap)
            {
                didFlap = false;
                rigidbody.velocity = new Vector2(0, bounceSpeed);
                //trigger flap animation
                anim.SetTrigger("Flap");
            }
        }
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }
}
