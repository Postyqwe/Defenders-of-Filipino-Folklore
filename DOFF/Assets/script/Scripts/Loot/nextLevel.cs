using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
    public DemoLoadScene scene;
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            scene.LoadScene(sceneToLoad);
        }
    }
}
