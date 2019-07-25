using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    void Awake()
    {
        //birds[GameController.instance.GetSelectedBird()].SetActive(true);
        MakeInstance();
    }

    private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        ScenceFader.instance.FadeIn("FlappyBird");
    }
}
