using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characters;
    public Transform spawner;

    private void Start()
    {
        // Check if PlayerPrefs has a saved SelectedCharacter index
        if (PlayerPrefs.HasKey("SelectedCharacter"))
        {
            int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter");

            // Ensure the index is within valid bounds
            if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characters.Length)
            {
                // Spawn the selected character at the spawner's position with a specific rotation
                Quaternion desiredRotation = Quaternion.Euler(30f, spawner.rotation.eulerAngles.y, spawner.rotation.eulerAngles.z);
                GameObject selectedCharacter = Instantiate(characters[selectedCharacterIndex], spawner.position, desiredRotation);
                // Optionally, you can set the selectedCharacter as a child of the spawner if needed
                selectedCharacter.transform.parent = spawner;
            }
            else
            {
                Debug.LogWarning("SelectedCharacter index is out of bounds.");
            }
        }
        else
        {
            Debug.LogWarning("SelectedCharacter not found in PlayerPrefs.");
        }
    }
}