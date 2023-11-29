using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private PlayerWeapons playerWeapons;
    [SerializeField] private Button slot1;
    [SerializeField] private Button slot2;

    private int Slot1 = 1; // Default to Slot 1
    private int Slot2 = 1;
    bool check = false;

    private void Start()
    {
        // Load the selected slot from PlayerPrefs
        if (PlayerPrefs.HasKey("SelectedSlot1"))
        {
            Slot1 = PlayerPrefs.GetInt("SelectedSlot1");
        }

        if (PlayerPrefs.HasKey("SelectedSlot2"))
        {
            Slot2 = PlayerPrefs.GetInt("SelectedSlot2");
        }

        // Add listeners to the UI buttons
        if (slot1 != null)
        {
            slot1.onClick.AddListener(SwitchToSlot1);
        }

        if (slot2 != null)
        {
            slot2.onClick.AddListener(SwitchToSlot2);
        }
    }
    private void Update()
    {
        playerWeapons = GameObject.FindGameObjectWithTag("WeaponHolder")?.GetComponent<PlayerWeapons>();
        if (playerWeapons != null && !check)
        {
            SwitchToSlot1();
            SwitchToSlot2();
            check = true;
        }
    }

    private void SwitchToSlot1()
    {
        if (playerWeapons != null)
        {
            playerWeapons.EquipWeapon(Slot1);
            UpdateButtonImage(slot1, Slot1, playerWeapons);
        }
    }

    private void SwitchToSlot2()
    {
        if (playerWeapons != null)
        {
            playerWeapons.EquipWeapon(Slot2);
            UpdateButtonImage(slot2, Slot2, playerWeapons);
        }
    }

    private void UpdateButtonImage(Button button, int slot, PlayerWeapons playerWeapons)
    {
        Image buttonImage = button?.transform.Find("Image").GetComponentInChildren<Image>();
        Sprite weaponSprite = playerWeapons?.GetCurrentWeaponSprite();

        if (buttonImage != null && weaponSprite != null)
        {
            buttonImage.sprite = weaponSprite;
        }
    }
}