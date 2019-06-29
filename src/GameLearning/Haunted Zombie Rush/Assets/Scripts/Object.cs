using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Move object from left to right
    /// delte is the time it's took to complete the last time
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.left * (20 * Time.deltaTime));
    }
}
