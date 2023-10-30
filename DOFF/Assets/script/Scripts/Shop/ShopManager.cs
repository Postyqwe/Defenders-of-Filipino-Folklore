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
    //shop items
    //Melee
    private bool hasMoroBarong;
    private bool hasKriss;
    private bool hasBolo;
    private bool hasTaga;
    private bool hasHanger;
    private bool hasWalisTambo;
    //Range
    private bool hasHandgun;
    private bool hasSlingShot;
    private bool hasBakya;
    private bool hasDyaryo;
    //Magic
    private bool hasMagicWand;
    private bool hasMagicOrb;

    public void LoadData(GameData data)
    {
        coinCount = data.coins;
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
                case 1:
                    hasMoroBarong = true;
                    break;
                case 2:
                    hasKriss = true;
                    break;
                case 3:
                    hasBolo = true;
                    break;
                case 4:
                    hasTaga = true;
                    break;
                case 5:
                    hasHanger = true;
                    break;
                case 6:
                    hasWalisTambo = true;
                    break;
                case 7:
                    hasHandgun = true;
                    break;
                case 8:
                    hasSlingShot = true;
                    break;
                case 9:
                    hasBakya = true;
                    break;
                case 10:
                    hasDyaryo = true;
                    break;
                case 11:
                    hasMagicWand = true;
                    break;
                case 12:
                    hasMagicOrb = true;
                    break;
                    // Add more cases for other items
            }
            Debug.Log("Item Puchased" + itemData.itemName);
        }
        else
        {
            Debug.Log("Not enough coins. mahirap");
        }
    }
}
