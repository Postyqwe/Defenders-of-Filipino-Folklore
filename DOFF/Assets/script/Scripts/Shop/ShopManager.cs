using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopManager : MonoBehaviour, IDataPersistence
{
    [Header("Coin UI")]
    public TMP_Text coinText;

    //Coins
    private int coinCount;
    //level
    public bool lvl1;
    public bool lvl2;
    public bool lvl3;
    public bool lvl4;
    public bool lvl5;
    public bool lvl6;
    public bool lvl7;

    //shop items
    //Melee
    public bool hasMoroBarong;
    public bool hasKriss;
    public bool hasBolo;
    public bool hasTaga;
    public bool hasHanger;
    public bool hasWalisTambo;
    //Range
    public bool hasHandgun;
    public bool hasSlingShot;
    public bool hasBakya;
    public bool hasDyaryo;
    //Magic
    public bool hasMagicWand;
    public bool hasMagicOrb;

    //upgrades
    public int lvlMoroBarong;
    public int lvlKriss;
    public int lvlBolo;
    public int lvlTaga;
    public int lvlHanger;
    public int lvlWalisTambo;
    //Range
    public int lvlHandgun;
    public int lvlSlingShot;
    public int lvlBakya;
    public int lvlDyaryo;
    //Magic
    public int lvlMagicWand;
    public int lvlMagicOrb;
    public void LoadData(GameData data)
    {
        coinCount = data.coins;
        lvl1 = data.lvl1;
        lvl2 = data.lvl2;
        lvl3 = data.lvl3;
        lvl4 = data.lvl4;
        lvl5 = data.lvl5;
        lvl6 = data.lvl6;
        lvl7 = data.lvl7;

        hasMoroBarong = data.hasMoroBarong;
        hasKriss = data.hasKriss;
        hasBolo = data.hasBolo;
        hasTaga = data.hasTaga;
        hasHanger = data.hasHanger;
        hasWalisTambo = data.hasWalisTambo;
        hasHandgun = data.hasHandgun;
        hasSlingShot = data.hasSlingShot;
        hasBakya = data.hasBakya;
        hasDyaryo = data.hasDyaryo;
        hasMagicWand = data.hasMagicWand;
        hasMagicOrb = data.hasMagicOrb;

        lvlBolo = data.lvlBolo;
        lvlHanger = data.lvlHanger;
        lvlKriss = data.lvlKriss;
        lvlMoroBarong = data.lvlMoroBarong;
        lvlTaga = data.lvlTaga;
        lvlWalisTambo = data.lvlWalisTambo;
        lvlHandgun = data.lvlHandgun;
        lvlSlingShot = data.lvlSlingShot;
        lvlBakya = data.lvlBakya;
        lvlDyaryo = data.lvlDyaryo;
        lvlMagicWand = data.lvlMagicWand;
        lvlMagicOrb = data.lvlMagicOrb;
    }

    public void SaveData(GameData data)
    {
        data.coins = coinCount;
        data.hasMoroBarong = hasMoroBarong;
        data.hasKriss = hasKriss;
        data.hasBolo = hasBolo;
        data.hasTaga = hasTaga;
        data.hasHanger = hasHanger;
        data.hasWalisTambo = hasWalisTambo;
        data.hasHandgun = hasHandgun;
        data.hasSlingShot = hasSlingShot;
        data.hasBakya = hasBakya;
        data.hasDyaryo = hasDyaryo;
        data.hasMagicWand = hasMagicWand;
        data.hasMagicOrb = hasMagicOrb;

        data.lvlBolo = lvlBolo;
        data.lvlHanger = lvlHanger;
        data.lvlKriss = lvlKriss;
        data.lvlMoroBarong = lvlMoroBarong;
        data.lvlTaga = lvlTaga;
        data.lvlWalisTambo = lvlWalisTambo;
        data.lvlHandgun = lvlHandgun;
        data.lvlSlingShot = lvlSlingShot;
        data.lvlBakya = lvlBakya;
        data.lvlDyaryo = lvlDyaryo;
        data.lvlMagicWand = lvlMagicWand;
        data.lvlMagicOrb = lvlMagicOrb;
    }

    private void Update()
    {
        coinText.SetText(coinCount.ToString());
    }

    public void PurchaseItem(int itemIndex, ShopItemsSO itemData)
    {
        if (coinCount >= itemData.price)
        {
            coinCount -= itemData.price;

            coinText.SetText(coinCount.ToString());

            switch (itemData.itemID)
            {
                case 0:
                    hasMagicWand = true;
                    break;
                case 1:
                    hasMagicOrb = true;
                    break;
                case 2:
                    hasBolo = true;
                    break;
                case 3:
                    hasHanger = true;
                    break;
                case 4:
                    hasKriss = true;
                    break;
                case 5:
                    hasMoroBarong = true;
                    break;
                case 6:
                    hasTaga = true;
                    break;
                case 7:
                    hasWalisTambo = true;
                    break;
                case 8:
                    hasHandgun = true;             
                    break;
                case 9:
                    hasSlingShot = true;
                    break;
                case 10:
                    hasBakya = true;
                    break;
                case 11:
                    hasDyaryo = true;
                    break;

            }
            Debug.Log("Item Puchased" + itemData.itemName);
        }
        else
        {
            Debug.Log("Not enough coins. mahirap");
        }
    }

    public void PurchaseUpgrade(int upgradeIndex)
    {
        // Get the base value for the upgrade
        int baseValue = 10;

        // Calculate the upgraded value based on the level
        int upgradedValue = (int)(baseValue * Mathf.Pow(2, GetUpgradeLevel(upgradeIndex)));

        // Check if the player has enough coins to purchase the upgrade
        if (coinCount >= upgradedValue)
        {
            // Deduct the coins
            coinCount -= upgradedValue;

            // Update the coin UI
            coinText.SetText(coinCount.ToString());

            // Increment the upgrade level
            IncrementUpgradeLevel(upgradeIndex);

            // Log the purchase
            Debug.Log("Upgrade Purchased: " + GetUpgradeName(upgradeIndex) + " - Level " + GetUpgradeLevel(upgradeIndex) + ", Value: " + upgradedValue);
        }
        else
        {
            Debug.Log("Not enough coins to purchase the upgrade.");
        }
    }

    public void IncrementUpgradeLevel(int upgradeIndex)
    {
        switch (upgradeIndex)
        {
            // Melee Upgrades
            case 0:
                lvlBolo++;
                break;
            case 1:
                lvlHanger++;
                break;
            case 2:
                lvlKriss++;
                break;
            case 3:
                lvlMoroBarong++;
                break;
            case 4:
                lvlTaga++;
                break;
            case 5:
                lvlWalisTambo++;
                break;

            // Range Upgrades
            case 6:
                lvlHandgun++;
                break;
            case 7:
                lvlSlingShot++;
                break;
            case 8:
                lvlBakya++;
                break;
            case 9:
                lvlDyaryo++;
                break;

            // Magic Upgrades
            case 10:
                lvlMagicWand++;
                break;
            case 11:
                lvlMagicOrb++;
                break;
        }
    }

    public int GetUpgradeLevel(int upgradeIndex)
    {
        switch (upgradeIndex)
        {
            // Melee Upgrades
            case 0:
                return lvlBolo;
            case 1:
                return lvlHanger;
            case 2:
                return lvlKriss;
            case 3:
                return lvlMoroBarong;
            case 4:
                return lvlTaga;
            case 5:
                return lvlWalisTambo;

            // Range Upgrades
            case 6:
                return lvlHandgun;
            case 7:
                return lvlSlingShot;
            case 8:
                return lvlBakya;
            case 9:
                return lvlDyaryo;

            // Magic Upgrades
            case 10:
                return lvlMagicWand;
            case 11:
                return lvlMagicOrb;

            default:
                return 0;
        }
    }

    public string GetUpgradeName(int upgradeIndex)
    {
        // You might want to return the name of the upgrade based on the index
        // Adjust this based on how you store upgrade names in your game
        // For example, you might have an array of upgrade names or a switch statement
        return "Upgrade " + upgradeIndex;
    }
}
