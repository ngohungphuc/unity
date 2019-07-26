using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    void Awake()
    {
        MakeInstance();
    }

    private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlayGame()
    {
        ScenceFader.instance.FadeIn("FlappyBird");
    }
}
