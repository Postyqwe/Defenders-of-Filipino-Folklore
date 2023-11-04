using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    public TMP_Text rewardsText;
    public GameObject rewardUI;
    public int coinReward;
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

    CoinBar coinBar;

    private void Start()
    {
        coinBar = GameObject.FindGameObjectWithTag("CoinCount").GetComponent<CoinBar>();
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
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins\n" + "+5 Hp\n" + "+0.3 Spd";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    break;

                case LevelClear.lvl2:
                    if (lvl2 == true)
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins\n" + "+5 Hp\n" + "+0.3 Spd";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    break;

                case LevelClear.lvl3:
                    if (lvl3 == true)
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins\n" + "+5 Hp\n" + "+0.3 Spd";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    break;

                case LevelClear.lvl4:
                    if (lvl4 == true)
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins\n" + "+5 Hp\n" + "+0.3 Spd";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    break;

                case LevelClear.lvl5:
                    if (lvl5 == true)
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins\n" + "+5 Hp\n" + "+0.3 Spd";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    break;

                case LevelClear.lvl6:
                    if (lvl6 == true)
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins\n" + "+5 Hp\n" + "+0.3 Spd";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    break;

                case LevelClear.lvl7:
                    if (lvl7 == true)
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
                    }
                    else
                    {
                        rewardsText.text = "Rewards: \n\n" + coinReward + " Coins\n" + "+5 Hp\n" + "+0.3 Spd";
                        rewardUI.SetActive(true);
                        RewardChecker();
                        scene.LoadScene(sceneToLoad);
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
}