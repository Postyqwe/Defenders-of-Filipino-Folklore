using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Item")]
public class ShopItemsSO : ScriptableObject
{
    public int itemID;
    public string itemName;
    public Sprite itemImage;
    public int price;
}
