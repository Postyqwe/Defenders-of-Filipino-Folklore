using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    private int selectedWeaponIndex = 0; // Default to index 0

    private void Start()
    {
        if (PlayerPrefs.HasKey("SelectedWeaponIndex"))
        {
            selectedWeaponIndex = PlayerPrefs.GetInt("SelectedWeaponIndex");
        }

        selectedWeaponIndex = Mathf.Clamp(selectedWeaponIndex, 0, weapons.Length - 1);

        SetActiveWeapon(selectedWeaponIndex);
    }

    public void SetActiveWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weapons.Length)
        {
            foreach (GameObject weapon in weapons)
            {
                weapon.SetActive(false);
            }

            weapons[weaponIndex].SetActive(true);

            selectedWeaponIndex = weaponIndex;

            PlayerPrefs.SetInt("SelectedWeaponIndex", selectedWeaponIndex);
            PlayerPrefs.Save();
        }
    }
}
