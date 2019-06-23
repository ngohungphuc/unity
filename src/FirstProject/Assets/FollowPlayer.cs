using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offSet;
    }
}
