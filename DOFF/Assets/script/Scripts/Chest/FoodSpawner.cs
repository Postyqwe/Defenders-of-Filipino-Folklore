using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodPrefabWithWeight
{
    public GameObject foodPrefab;
    public float spawnWeight;
}

public class FoodSpawner : MonoBehaviour
{
    public float spawnTimer;
    public bool spawnEnabled = true;

    private GameObject currentFood;

    public List<FoodPrefabWithWeight> foodPrefabs = new List<FoodPrefabWithWeight>();

    private float totalWeight;

    private void Start()
    {
        totalWeight = 0f;
        foreach (var foodPrefab in foodPrefabs)
        {
            totalWeight += foodPrefab.spawnWeight;
        }

        if (spawnEnabled)
        {
            InvokeRepeating("SpawnRandomFood", spawnTimer, spawnTimer);
        }
    }

    public void SpawnRandomFood()
    {
        if (!spawnEnabled || totalWeight == 0 || currentFood != null)
        {
            return;
        }

        float randomValue = Random.Range(0f, totalWeight);

        float weightSum = 0f;
        foreach (var foodPrefab in foodPrefabs)
        {
            weightSum += foodPrefab.spawnWeight;
            if (randomValue <= weightSum)
            {
                currentFood = Instantiate(foodPrefab.foodPrefab, transform);
                currentFood.transform.localPosition = Vector3.zero;
                currentFood.transform.localRotation = Quaternion.identity;
                return;
            }
        }

        Debug.LogWarning("No food prefab selected. This should not happen.");
    }
}
