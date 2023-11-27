using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public List<GameObject> slot1Weapons;
    public List<GameObject> slot2Weapons;

    private List<GameObject> currentWeapons;

    void Start()
    {
        SwitchSlot(1); // Start with Slot 1
    }

    // Call these methods when the corresponding buttons are pressed

    public void OnSlot1ButtonPressed()
    {
        SwitchSlot(1);
    }

    public void OnSlot2ButtonPressed()
    {
        SwitchSlot(2);
    }

    // Example: Call this method when a weapon button in the UI is pressed
    public void OnWeaponButtonPressed(int weaponIndex)
    {
        EquipWeapon(weaponIndex);
    }

    void SwitchSlot(int slotIndex)
    {
        // Deactivate all current weapons
        DeactivateWeapons();

        // Set current weapons based on the slot index
        currentWeapons = (slotIndex == 1) ? slot1Weapons : slot2Weapons;

        // Activate the default weapon in the current slot
        if (currentWeapons.Count > 0)
        {
            currentWeapons[0].SetActive(true);
        }

        // Example: Print a message indicating the current slot
        Debug.Log("Switched to Slot " + slotIndex);
    }

    void EquipWeapon(int weaponIndex)
    {
        // Ensure the index is within bounds
        if (weaponIndex >= 0 && weaponIndex < currentWeapons.Count)
        {
            // Deactivate all weapons
            DeactivateWeapons();

            // Activate the selected weapon
            currentWeapons[weaponIndex].SetActive(true);

            // Example: Print a message indicating the equipped weapon
            Debug.Log("Equipped " + currentWeapons[weaponIndex].name);
        }
        else
        {
            Debug.LogWarning("Invalid weapon index: " + weaponIndex);
        }
    }

    void DeactivateWeapons()
    {
        // Deactivate all current weapons
        foreach (var weapon in currentWeapons)
        {
            weapon.SetActive(false);
        }
    }
}
