using EasyTransition;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public string sceneName = "Map";
    public DemoLoadScene Transition;

    public void PickJuan()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 0);
        PlayerPrefs.Save();
        Transition.LoadScene(sceneName);
    }

    public void PickMarites()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 1);
        PlayerPrefs.Save();
        Transition.LoadScene(sceneName);
    }
}
