using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour, IDataPersistence
{
    public GameObject achievementHolder;
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

    private bool isOpened = false;
    private void Update()
    {
        a1.interactable = ach1;
        a2.interactable = ach2;
        a3.interactable = ach3;
        a4.interactable = ach4;
        a5.interactable = ach5;
        a6.interactable = ach6;
        a7.interactable = ach7;
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
    }

    public void SaveData(GameData data)
    {

    }

    public void AchievementDisplay(string title, Sprite icon, string descripton)
    {
        titleHolder.text = title;
        iconHolder.sprite = icon;
        descriptionHolder.text = descripton;

        displayerHolder.SetActive(true);
        listHodler.SetActive(false);
        isOpened = true;
    }
    public void AchievementClose()
    {
        if (isOpened == false)
        {
            achievementHolder.SetActive(false);
        }
        else
        {
            displayerHolder.SetActive(false);
            listHodler.SetActive(true);
        }
    }
}
