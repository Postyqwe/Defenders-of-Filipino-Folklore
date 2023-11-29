using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public ShopItemsSO shopItemData;
    public ShopManager shopManager;

    Button upgradeButton;
    TMP_Text upPrice;
    TMP_Text levelWeapon;

    Button buyButton;
    TMP_Text priceText;
    
    Image coinImg;
    Image lockImg;

    GameObject locker;
    private string lvl;

    int levelcounter;
    private void Start()
    {
        locker = transform.Find("Locker").gameObject;
        TMP_Text lockerTxt = locker.transform.Find("LevelS").GetComponent<TMP_Text>();

        TMP_Text nameText = transform.Find("Name").GetComponent<TMP_Text>();
        Image itemImage = transform.Find("Image").GetComponent<Image>();

        Transform upgrade = transform.Find("Upgrade");
        levelWeapon = upgrade.Find("Level").GetComponent<TMP_Text>();
        upgradeButton = upgrade.Find("Button").GetComponent<Button>();
        upPrice = upgradeButton.GetComponentInChildren<TMP_Text>();

        buyButton = transform.Find("Buy").GetComponent<Button>();
        priceText = buyButton.transform.Find("Price").GetComponent<TMP_Text>();
        coinImg = buyButton.transform.Find("Coin").GetComponent<Image>();
        lockImg = buyButton.transform.Find("Lock").GetComponent<Image>();

        levelcounter = shopManager.GetUpgradeLevel(shopItemData.itemID);
        int isUnlocked = CheckUnlock(shopItemData);


        if (shopItemData != null)
        {
            nameText.text = shopItemData.itemName;
            itemImage.sprite = shopItemData.itemImage;

            int itemLevel = GetItemLevel(shopItemData);
            if (isUnlocked > 0)
            {
                locker.SetActive(false);
                coinImg.enabled = false;
                lockImg.enabled = false;
                levelWeapon.text = "+" + levelcounter.ToString();
                upPrice.text = (10 * levelcounter).ToString();
                priceText.text = "Equip";
                upgradeButton.onClick.AddListener(() => OnUpgrade(shopItemData.itemID));
                buyButton.onClick.AddListener(() => OnEquipItem(shopItemData.itemID));
            }
            else
            {
                if (itemLevel > 0)
                {
                    levelWeapon.text = "";
                    upPrice.text = "";
                    upgradeButton.interactable = false;
                    locker.SetActive(false);
                    priceText.text = shopItemData.price.ToString();
                    buyButton.onClick.AddListener(() => OnBuyItem(shopItemData));
                    coinImg.enabled = true;
                    lockImg.enabled = false;
                }
                else
                {
                    levelWeapon.text = "";
                    upPrice.text = "";
                    upgradeButton.interactable = false;
                    lockerTxt.text = "Unlock after " + lvl;
                    priceText.text = "Locked";
                    buyButton.interactable = false;
                    coinImg.enabled = false;
                    lockImg.enabled = true;
                }
            }
        }
    }
    private int CheckUnlock(ShopItemsSO item)
    {
        switch (item.itemID)
        {
            case 0:
                return shopManager.hasMagicWand ? 1 : 0;
            case 1:
                return shopManager.hasMagicOrb ? 1 : 0;
            case 2:
                return shopManager.hasBolo ? 1 : 0;
            case 3:
                return shopManager.hasHanger ? 1 : 0;
            case 4:
                return shopManager.hasKriss ? 1 : 0;
            case 5:
                return shopManager.hasMoroBarong ? 1 : 0;
            case 6:
                return shopManager.hasTaga ? 1 : 0;
            case 7:
                return shopManager.hasWalisTambo ? 1 : 0;
            case 8:
                return shopManager.hasHandgun ? 1 : 0;
            case 9:
                return shopManager.hasSlingShot ? 1 : 0;
            case 10:
                return shopManager.hasBakya ? 1 : 0;
            case 11:
                return shopManager.hasDyaryo ? 1 : 0;
            default:
                return 1;
        }
    }

    private int GetItemLevel(ShopItemsSO item)
    {
        switch (item.itemID)
        {
            case 0:
                lvl = "Level 1";
                return shopManager.lvl1 ? 1 : 0;
            case 1:
                lvl = "Level 3";
                return shopManager.lvl3 ? 1 : 0;
            case 2:
                lvl = "Level 2";
                return shopManager.lvl2 ? 1 : 0;
            case 3:
                lvl = "Level 6";
                return shopManager.lvl6 ? 1 : 0;
            case 4:
                lvl = "Level 4";
                return shopManager.lvl4 ? 1 : 0;
            case 5:
                lvl = "Level 5";
                return shopManager.lvl5 ? 1 : 0;
            case 6:
                lvl = "Level 1";
                return shopManager.lvl1 ? 1 : 0;
            case 7:
                lvl = "Level 6";
                return shopManager.lvl6 ? 1 : 0;
            case 8:
                lvl = "Level 2";
                return shopManager.lvl2 ? 1 : 0;
            case 9:
                lvl = "Level 1";
                return shopManager.lvl1 ? 1 : 0;
            case 10:
                lvl = "Level 6";
                return shopManager.lvl6 ? 1 : 0;
            case 11:
                lvl = "Level 6";
                return shopManager.lvl6 ? 1 : 0;
            default:
                return 1;
        }
    }

    public void OnBuyItem(ShopItemsSO shopItems)
    {
        if (shopManager != null && shopItemData != null)
        {
            int itemId = shopItems.itemID;
            shopManager.PurchaseItem(itemId, shopItemData);

            buyButton.interactable = true;

            priceText.text = "Equip";

            coinImg.enabled = false;
            lockImg.enabled = false;

            buyButton.onClick.AddListener(() => OnEquipItem(shopItemData.itemID));
        }
        else
        {
            Debug.LogWarning("ShopManager or ShopItemData reference is missing. Make sure they are assigned in the Unity Inspector.");
        }
    }

    public void OnUpgrade(int shopItems)
    {
        shopManager.PurchaseUpgrade(shopItems);
        upPrice.text = (10 * shopManager.GetUpgradeLevel(shopItems)).ToString();
        levelWeapon.text = "+" + shopManager.GetUpgradeLevel(shopItems).ToString();
    }
    public void OnEquipItem(int index)
    {
        int currentSlot = PlayerPrefs.GetInt("SelectedSlot", 1); // Default to Slot 1

        if (currentSlot == 1)
        {
            PlayerPrefs.SetInt("SelectedSlot1", index);
            PlayerPrefs.SetInt("SelectedSlot", 2); // Switch to Slot 2
        }
        else
        {
            PlayerPrefs.SetInt("SelectedSlot2", index);
            PlayerPrefs.SetInt("SelectedSlot", 1); // Switch to Slot 1
        }

        PlayerPrefs.Save();

        Debug.Log("Equipped item with ID: " + index + " in Slot " + PlayerPrefs.GetInt("SelectedSlot"));
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("SelectedSlot"))
        {
            int currentSlot = PlayerPrefs.GetInt("SelectedSlot");

            int itemUnlock = CheckUnlock(shopItemData); // You need to define the CheckUnlock method
            if (itemUnlock == 1)
            {
                int indexSlot1 = PlayerPrefs.GetInt("SelectedSlot1");
                int indexSlot2 = PlayerPrefs.GetInt("SelectedSlot2");

                if (indexSlot1 == shopItemData.itemID && currentSlot == 1)
                {
                    priceText.text = "Equipped Slot 1";
                    buyButton.interactable = false;
                }
                else if (indexSlot2 == shopItemData.itemID && currentSlot == 2)
                {
                    priceText.text = "Equipped Slot 2";
                    buyButton.interactable = false;
                }
                else
                {
                    priceText.text = "Equip";
                    buyButton.interactable = true;
                }
            }
        }
        else
        {
            PlayerPrefs.SetInt("SelectedSlot", 1);
            PlayerPrefs.Save();
        }
    }
}
