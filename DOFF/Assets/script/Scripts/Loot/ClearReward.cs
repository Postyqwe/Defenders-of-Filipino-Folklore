using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public enum LevelClear
{
    None,
    lvl1,
    lvl2,
    lvl3,
    lvl4,
    lvl5,
    lvl6,
    lvl7,
}
public class ClearReward : MonoBehaviour,IDataPersistence
{
    public LevelClear lvlClear;
    public int coinReward;
    public GameObject rewardUI;
    
    [Header("Cleared UI")]
    public GameObject clearedUI;
    public TMP_Text clearRewardTxt;

    [Header("Not Cleared UI")]
    public GameObject notClearedUI;
    public int statsAmount;
    public TMP_Text label;
    public TMP_Text hp;
    public TMP_Text spd;
    public Button hpBtn;
    public Button spdBtn;

    [Header("Scene Transition")]
    public DemoLoadScene scene;
    public string sceneToLoad;

    private int coins;
    private bool lvl1;
    private bool lvl2;
    private bool lvl3;
    private bool lvl4;
    private bool lvl5;
    private bool lvl6;
    private bool lvl7;

    private int hpLoad;
    private int spdLoad;
    CoinBar coinBar;

    private void Start()
    {
        coinBar = GameObject.FindGameObjectWithTag("CoinCount").GetComponent<CoinBar>();
        hp.text = hpLoad.ToString();
        spd.text = spdLoad.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch (lvlClear)
            {
                case LevelClear.lvl1:
                    if(lvl1 == true)
                    {
                        clearRewardTxt.text = "Rewards: \n" + coinReward + " Coins\n";
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(true);
                        notClearedUI.SetActive(false);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(false);
                        notClearedUI.SetActive(true);
                        RewardChecker();
                    }
                    break;

                case LevelClear.lvl2:
                    if (lvl2 == true)
                    {
                        clearRewardTxt.text = "Rewards: \n" + coinReward + " Coins\n";
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(true);
                        notClearedUI.SetActive(false);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(false);
                        notClearedUI.SetActive(true);
                        RewardChecker();
                    }
                    break;

                case LevelClear.lvl3:
                    if (lvl3 == true)
                    {
                        clearRewardTxt.text = "Rewards: \n" + coinReward + " Coins\n";
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(true);
                        notClearedUI.SetActive(false);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(false);
                        notClearedUI.SetActive(true);
                        RewardChecker();
                    }
                    break;

                case LevelClear.lvl4:
                    if (lvl4 == true)
                    {
                        clearRewardTxt.text = "Rewards: \n" + coinReward + " Coins\n";
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(true);
                        notClearedUI.SetActive(false);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(false);
                        notClearedUI.SetActive(true);
                        RewardChecker();
                    }
                    break;

                case LevelClear.lvl5:
                    if (lvl5 == true)
                    {
                        clearRewardTxt.text = "Rewards: \n" + coinReward + " Coins\n";
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(true);
                        notClearedUI.SetActive(false);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(false);
                        notClearedUI.SetActive(true);
                        RewardChecker();
                    }
                    break;

                case LevelClear.lvl6:
                    if (lvl6 == true)
                    {
                        clearRewardTxt.text = "Rewards: \n" + coinReward + " Coins\n";
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(true);
                        notClearedUI.SetActive(false);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(false);
                        notClearedUI.SetActive(true);
                        RewardChecker();
                    }
                    break;

                case LevelClear.lvl7:
                    if (lvl7 == true)
                    {
                        clearRewardTxt.text = "Rewards: \n" + coinReward + " Coins\n";
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(true);
                        notClearedUI.SetActive(false);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
                        rewardUI.SetActive(true);
                        clearedUI.SetActive(false);
                        notClearedUI.SetActive(true);
                        RewardChecker();
                    }
                    break;

                default:
                    break;
            }
        }
    }
    public void LoadData(GameData data)
    {
        coins = data.coins;
        lvl1 = data.lvl1;
        lvl2 = data.lvl2;
        lvl3 = data.lvl3;
        lvl4 = data.lvl4;
        lvl5 = data.lvl5;
        lvl6 = data.lvl6;
        lvl7 = data.lvl7;

        hpLoad = data.healthLevel;
        spdLoad = data.speedLevel;
    }

    public void SaveData(GameData data)
    {
        data.coins = coins;
        data.lvl1 = lvl1;
        data.lvl2 = lvl2;
        data.lvl3 = lvl3;
        data.lvl4 = lvl4;
        data.lvl5 = lvl5;
        data.lvl6 = lvl6;
        data.lvl7 = lvl7;
        data.healthLevel = hpLoad;
        data.speedLevel = spdLoad;
    }

    void RewardChecker()
    {
        switch (lvlClear)
        {
            case LevelClear.lvl1:
                coins += coinReward;
                coinBar.GetCoin(coinReward);
                lvl1 = true;
                DataPersistenceManager.instance.SaveGame();
                break;

            case LevelClear.lvl2:
                coins += coinReward;
                coinBar.GetCoin(coinReward);
                lvl2 = true;
                DataPersistenceManager.instance.SaveGame();
                break;

            case LevelClear.lvl3:
                coins += coinReward;
                coinBar.GetCoin(coinReward);
                lvl3 = true;
                DataPersistenceManager.instance.SaveGame();
                break;

            case LevelClear.lvl4:
                coins += coinReward;
                coinBar.GetCoin(coinReward);
                lvl4 = true;
                DataPersistenceManager.instance.SaveGame();
                break;

            case LevelClear.lvl5:
                coins += coinReward;
                coinBar.GetCoin(coinReward);
                lvl5 = true;
                DataPersistenceManager.instance.SaveGame();
                break;

            case LevelClear.lvl6:
                coins += coinReward;
                coinBar.GetCoin(coinReward);
                lvl6 = true;
                DataPersistenceManager.instance.SaveGame();
                break;

            case LevelClear.lvl7:
                coins += coinReward;
                coinBar.GetCoin(coinReward);
                lvl7 = true;
                DataPersistenceManager.instance.SaveGame();
                break;

            default:
                break;
        }

    }

    public void Health()
    {
        if(statsAmount == 1)
        {
            statsAmount--;
            hpLoad++;
            hp.text = hpLoad.ToString();
            hpBtn.interactable = false;
            spdBtn.interactable = false;
            label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
            DataPersistenceManager.instance.SaveGame();
            scene.LoadScene(sceneToLoad);
        }
        statsAmount--;
        hpLoad++;
        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
        hp.text = hpLoad.ToString();
        DataPersistenceManager.instance.SaveGame();
    }
    public void Speed()
    {
        if (statsAmount == 1)
        {
            statsAmount--;
            hpLoad++;
            hp.text = hpLoad.ToString();
            hpBtn.interactable = false;
            spdBtn.interactable = false;
            label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
            DataPersistenceManager.instance.SaveGame();
            scene.LoadScene(sceneToLoad);
        }
        statsAmount--;
        spdLoad++;
        label.text = "Rewards: \n" + coinReward + " Coins\n" + "Can add " + statsAmount;
        spd.text = spdLoad.ToString();
        DataPersistenceManager.instance.SaveGame();
    }
}