using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour, IDataPersistence
{
    public GameObject achievementHolder;
    [Header("ProgressBar")]
    public Slider progressBar;
    public int totalAchs = 7;
    public TMP_Text achAmount;

    [Header("List UI")]
    public GameObject listHodler;
    public Button a1;
    public Button a2;
    public Button a3;
    public Button a4;
    public Button a5;
    public Button a6;
    public Button a7;

    [Header("Display Achievement UI")]
    public GameObject progresBarUI;
    public GameObject displayerHolder;
    public TMP_Text titleHolder;
    public Image iconHolder;
    public TMP_Text descriptionHolder;

    [Header("Debugging")]
    public bool ach1;
    public bool ach2;
    public bool ach3;
    public bool ach4;
    public bool ach5;
    public bool ach6;
    public bool ach7;
    [Space]
    public int killedTyanak;
    public int killedTikbalang;
    public int killedMananangal;
    public int killedMangkukulam;
    public int killedWhiteLady;
    public int killedKapre;
    public int killedFinalBoss;

    private bool isOpened = false;
    private void Start()
    {
        progressBar.maxValue = totalAchs;

        if (killedTyanak >= 10)
        {
            ach1 = true;
        }

        if (killedTikbalang >= 15)
        {
            ach2 = true;
        }

        if (killedMananangal >= 15)
        {
            ach3 = true;
        }

        if (killedMangkukulam >= 10)
        {
            ach4 = true;
        }

        if (killedWhiteLady >= 10)
        {
            ach5 = true;
        }

        if (killedKapre >= 10) 
        {
            ach6 = true;
        }

        if (killedFinalBoss >= 1)
        {
            ach7 = true;
        }
    }
    private void Update()
    {
        a1.interactable = ach1;
        a2.interactable = ach2;
        a3.interactable = ach3;
        a4.interactable = ach4;
        a5.interactable = ach5;
        a6.interactable = ach6;
        a7.interactable = ach7;

        int trueAchievements = (ach1 ? 1 : 0) + (ach2 ? 1 : 0) + (ach3 ? 1 : 0) + (ach4 ? 1 : 0) + (ach5 ? 1 : 0) + (ach6 ? 1 : 0) + (ach7 ? 1 : 0);
        progressBar.value = trueAchievements;
        achAmount.text = trueAchievements + " / " + totalAchs;
    }
    public void LoadData(GameData data)
    {
        ach1 = data.ach1;
        ach2 = data.ach2;
        ach3 = data.ach3;
        ach4 = data.ach4;
        ach5 = data.ach5;
        ach6 = data.ach6;
        ach7 = data.ach7;

        killedTyanak = data.killedTyanak;
        killedTikbalang = data.killedTikbalang;
        killedMananangal = data.killedMananangal;
        killedMangkukulam = data.killedMangkukulam;
        killedWhiteLady = data.killedWhiteLady;
        killedKapre = data.killedKapre;
        killedFinalBoss = data.killedFinalBoss;
    }

    public void SaveData(GameData data)
    {

    }

    public void AchievementDisplay(string title, Sprite icon, string descripton)
    {
        titleHolder.text = title;
        iconHolder.sprite = icon;
        descriptionHolder.text = descripton;

        progresBarUI.SetActive(false);
        displayerHolder.SetActive(true);
        listHodler.SetActive(false);
        isOpened = true;
    }
    public void AchievementClose()
    {
        if (isOpened == false)
        {
            progresBarUI.SetActive(false);
            achievementHolder.SetActive(false);
        }
        else
        {
            progresBarUI.SetActive(true);
            displayerHolder.SetActive(false);
            listHodler.SetActive(true);
        }
    }
}
