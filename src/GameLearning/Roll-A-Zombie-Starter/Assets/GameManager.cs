using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int selectedZombiePosition = 0;

    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 selectedSize;
    public Vector3 defaultSize;

    // Start is called before the first frame update
    void Start()
    {
        SelectZombie(selectedZombie);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            GetZomebieLeft();
        }

        if (Input.GetKeyDown("right"))
        {
            GetZomebieRight();
        }

        if (Input.GetKeyDown("up"))
        {
            PushUp();
        }
    }

    void GetZomebieLeft()
    {
        if (selectedZombiePosition == 0)
        {
            selectedZombiePosition = 3;
            SelectZombie(zombies[3]);
        }
        else
        {
            selectedZombiePosition = selectedZombiePosition - 1;
            GameObject newZombie = zombies[selectedZombiePosition];
            SelectZombie(newZombie);
        }
    }

    void GetZomebieRight()
    {
        if (selectedZombiePosition == 3)
        {
            selectedZombiePosition = 0;
            SelectZombie(zombies[0]);
        }
        else
        {
            selectedZombiePosition = selectedZombiePosition + 1;
            GameObject newZombie = zombies[selectedZombiePosition];
            SelectZombie(newZombie);
        }
    }

    void SelectZombie(GameObject newZomeBie)
    {
        selectedZombie.transform.localScale = defaultSize;
        selectedZombie = newZomeBie;
        newZomeBie.transform.localScale = selectedSize;
    }

    void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }
}
