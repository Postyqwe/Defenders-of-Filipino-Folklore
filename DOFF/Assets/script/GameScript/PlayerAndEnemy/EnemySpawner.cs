using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] prefab;
    public GameObject[] SpawnPoints;
    public int maxSpawns;
    public float spawnInterval;
    private int prefabIndex;
    private int spawnIndex;
    private int spawnCount;

    void Start()
    {
        spawnCount = 0;
        Instantiate(prefab[0], SpawnPoints[0].transform.position, Quaternion.identity);
        Instantiate(prefab[1], SpawnPoints[1].transform.position, Quaternion.identity);
        StartCoroutine(SpawnPrefab());
    }

    IEnumerator SpawnPrefab()
    {
        while (spawnCount < maxSpawns)
        {
            Instantiate(prefab[prefabIndex % 2], SpawnPoints[spawnIndex % 2].transform.position, Quaternion.identity);
            prefabIndex++;
            spawnIndex++;
            spawnCount++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}