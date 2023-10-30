using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public ShopItemsSO shopItemData;

    public ShopManager shopManager;
    private void Start()
    {
        // You can access the components attached to this GameObject
        TMP_Text nameText = transform.Find("Name").GetComponent<TMP_Text>();
        Image itemImage = transform.Find("Image").GetComponent<Image>();
        Button buyButton = transform.Find("Buy").GetComponent<Button>();
        TMP_Text priceText = buyButton.transform.Find("Price").GetComponent<TMP_Text>();

        // Use these components to set item name, image, and price
        if (shopItemData != null)
        {
            nameText.text = shopItemData.itemName;
            itemImage.sprite = shopItemData.itemImage;
            priceText.text = shopItemData.price.ToString();
            buyButton.onClick.AddListener(() => OnBuyItem(shopItemData));
        }
    }

    public void OnBuyItem(ShopItemsSO shopItems)
    {
        if (shopManager != null && shopItemData != null)
        {
            int itemId = shopItems.itemID;
            // Call the PurchaseItem method in the ShopManager to buy the item
            shopManager.PurchaseItem(itemId,shopItemData);
        }
        else
        {
            Debug.LogWarning("ShopManager or ShopItemData reference is missing. Make sure they are assigned in the Unity Inspector.");
        }
    }
}
