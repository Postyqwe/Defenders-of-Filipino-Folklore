using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncycScene : MonoBehaviour
{
    
    public void LoadScene()
    {
        SceneManager.LoadScene("bestiary");
    }
}
