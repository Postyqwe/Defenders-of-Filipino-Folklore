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

    public void LoadData(GameData data)
    {
        coinCount = data.coins;
        lvl1 = true;
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
}
