using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private float objectSpeed = 1;

    [SerializeField] private float resetPosition = -21.56f;

    [SerializeField] private float startPosition = 76f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /// <summary>
    /// Move object from left to right
    /// delte is the time it's took to complete the last time
    /// </summary>
    protected virtual void Update()
    {
        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

        if (transform.localPosition.x <= resetPosition)
        {
            Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
