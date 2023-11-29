using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponPrefabs;
    private int selectedWeaponIndex = 6; // Default index
    private GameObject currentWeapon;

    public int SelectedWeaponIndex
    {
        get { return selectedWeaponIndex; }
    }

    public int WeaponCount
    {
        get { return weaponPrefabs.Length; }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("SelectedWeaponIndex"))
        {
            selectedWeaponIndex = PlayerPrefs.GetInt("SelectedWeaponIndex");
        }

        selectedWeaponIndex = Mathf.Clamp(selectedWeaponIndex, 0, weaponPrefabs.Length - 1);

        EquipWeapon(selectedWeaponIndex);
    }

    public void EquipWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weaponPrefabs.Length)
        {
            if (currentWeapon != null)
            {
                Destroy(currentWeapon);
            }

            currentWeapon = Instantiate(weaponPrefabs[weaponIndex], transform.position, Quaternion.identity, transform);

            selectedWeaponIndex = weaponIndex;
            Debug.Log("Weapon loaded: " + selectedWeaponIndex);

            PlayerPrefs.SetInt("SelectedWeaponIndex", selectedWeaponIndex);
            PlayerPrefs.Save();
        }
    }

    public Sprite GetCurrentWeaponSprite()
    {
        if (currentWeapon != null)
        {
            SpriteRenderer weaponSpriteRenderer = currentWeapon.GetComponent<SpriteRenderer>();
            if (weaponSpriteRenderer != null)
            {
                return weaponSpriteRenderer.sprite;
            }
        }

        return null;
    }
}
