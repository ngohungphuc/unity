﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 8f;
    public float MaxVelocity = 4f;

    private Rigidbody2D MyBody;
    private Animator Anim;

    void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(MyBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (vel < MaxVelocity)
            {
                forceX = Speed;
            }
        }
        else if (h < 0)
        {
            if (vel < MaxVelocity)
            {
                forceX = -Speed;
            }
        }

        MyBody.AddForce(new Vector2(forceX, 0));
    }
}
