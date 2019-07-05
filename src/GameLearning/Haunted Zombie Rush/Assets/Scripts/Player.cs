using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private AudioClip sfxJump;

    private Animator animator;
    private Rigidbody rigidbody;
    private bool jump = false;
    private AudioSource audioSource;

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
        if(Input.GetMouseButtonDown(0))
        {
            animator.Play("Jump");
            audioSource.PlayOneShot(sfxJump);
            rigidbody.useGravity = true;
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if(jump)
        {
            jump = false;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }
}
