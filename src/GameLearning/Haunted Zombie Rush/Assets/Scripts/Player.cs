using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;

    private Animator animator;
    private Rigidbody rigidbody;
    private bool jump = false;
    private AudioSource audioSource;

    void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStartedGame();
                animator.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidbody.useGravity = true;
                jump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            rigidbody.AddForce(new Vector2(-50, 20), ForceMode.Impulse);
            rigidbody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();
        }
    }
}
