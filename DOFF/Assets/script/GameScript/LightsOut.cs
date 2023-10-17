using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public GameObject[] lights;
    public int numberOfLightsToTurnOff;
    public float timeToTurnOffLights;

    private int numberOfLightsTurnedOff;
    private bool gameStarted;

    void Start()
    {
        gameStarted = false;
        numberOfLightsTurnedOff = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartCoroutine(TurnOffLights());
            gameStarted = true;
        }
    }

    IEnumerator TurnOffLights()
    {
        while (numberOfLightsTurnedOff < numberOfLightsToTurnOff)
        {
            int randomIndex = Random.Range(0, lights.Length);
            if (!lights[randomIndex].activeSelf)
            {
                lights[randomIndex].SetActive(true);
                numberOfLightsTurnedOff++;
            }
            yield return new WaitForSeconds(timeToTurnOffLights);
        }

        if (numberOfLightsTurnedOff >= numberOfLightsToTurnOff)
        {
            Debug.Log("All lights turned off!");
        }
    }
}
