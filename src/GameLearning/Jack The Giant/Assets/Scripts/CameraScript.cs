using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float speed = 1f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    [HideInInspector]
    public bool moveCamera;
    // Start is called before the first frame update
    void Start()
    {
        moveCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCamera)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        //position of camera
        Vector3 temp = transform.position;

        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);

        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        speed += acceleration * Time.deltaTime;

        transform.position = temp;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
