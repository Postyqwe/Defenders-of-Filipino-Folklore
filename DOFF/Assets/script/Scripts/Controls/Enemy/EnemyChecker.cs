using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public GameObject barrier;
    public EnemyAI[] enemies;
    private int counter;
    private bool[] hasBeenCounted;

    private void Start()
    {
        counter = enemies.Length;
        hasBeenCounted = new bool[enemies.Length];
    }

    private void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null && !hasBeenCounted[i])
            {
                counter--;
                hasBeenCounted[i] = true;
            }
        }

        if (counter <= 0)
        {
            barrier.SetActive(false);
        }
    }
}
