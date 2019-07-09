using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int target = 0;
    public Transform exitPoint;
    public Transform[] wayPoints;
    public float navigationUpdate;

    private Transform enemy;
    private float navigationTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints != null)
        {
            navigationTime += Time.deltaTime;

            if (navigationTime > navigationUpdate)
            {
                if (target < wayPoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, navigationTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                }

                navigationTime = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "checkpoint")
        {
            target += 1;
        }
        else if (collider2D.tag == "Finish")
        {
            GameManager.instance.RemoveEnemyFromScreen();
            Destroy(gameObject);
        }
    }
}
