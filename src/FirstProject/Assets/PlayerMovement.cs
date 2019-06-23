using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    //void Start()
    //{
    //    //rigidbody.useGravity = false;
    //    rigidbody.AddForce(0, 200, 500);
    //}


    /// <summary>
    /// Update is called once per frame
    /// Use FixedUpdate when we want to mess with physic not Updated
    /// </summary>
    void FixedUpdate()
    {
        rigidbody.AddForce(0, 0, 2000 * Time.deltaTime);
    }
}
