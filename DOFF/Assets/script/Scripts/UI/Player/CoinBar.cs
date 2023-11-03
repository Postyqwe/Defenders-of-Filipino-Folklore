using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBar : MonoBehaviour, IDataPersistence
{
    public TMP_Text coinText;

    [Header("Debugging")]
    public int coinCount;

    private void Update()
    {
        coinText.text = coinCount.ToString();
    }

    public void LoadData(GameData data)
    {
        coinCount = data.coins;
    }

    public void SaveData(GameData data)
    {
        data.coins = coinCount;
    }

    public void GetCoin(int coin)
    {
        coinCount += coin;
        DataPersistenceManager.instance.SaveGame();
    }
}