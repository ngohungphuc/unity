using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;

    public float forwardForce = 2000f;

    public float sidewaysForce = 500f;
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
        rigidbody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rigidbody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rigidbody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rigidbody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
