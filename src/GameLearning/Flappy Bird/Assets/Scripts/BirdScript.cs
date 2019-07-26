using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public static BirdScript instance;
    public bool isAlive;
    public int score;

    [SerializeField]
    private Rigidbody2D myRigidBody;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flapClick, pointClip, diedClip;
    private Button flapButton;
    private float forwardSpeed = 3f;
    private float bounceSpeed = 4f;
    private bool didFlap;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isAlive = true;
        score = 0;
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
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if (didFlap)
            {
                didFlap = false;
                myRigidBody.velocity = new Vector2(0, bounceSpeed);
                audioSource.PlayOneShot(flapClick);
                //trigger flap animation
                anim.SetTrigger("Flap");
            }

            if (myRigidBody.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -myRigidBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    void SetCameraX()
    {
        CaneraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }

    /// <summary>
    /// if bird collision with ground or pipe -> died
    /// </summary>
    /// <param name="target"></param>
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe")
        {
            if (isAlive)
            {
                isAlive = false;
                anim.SetTrigger("Bird Died");
                audioSource.PlayOneShot(diedClip);
                GamePlayController.instance.PlayerDiedShowScore(score);
            }
        }
    }

    /// <summary>
    /// if bird get pass 1 pipe + 1 point
    /// </summary>
    /// <param name="target"></param>
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "PipeHolder")
        {
            score++;
            GamePlayController.instance.SetScore(score);
            audioSource.PlayOneShot(pointClip);
        }
    }
}
