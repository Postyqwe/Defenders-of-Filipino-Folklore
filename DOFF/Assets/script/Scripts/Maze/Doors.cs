using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject barrier;

    private void Update()
    {
        if (hasKey)
        {
            barrier.SetActive(false);
        }
    }
}
