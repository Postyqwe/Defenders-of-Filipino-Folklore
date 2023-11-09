using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeastiaryManager : MonoBehaviour, IDataPersistence
{
    [Header("Minions UI")]
    public GameObject minionsContainer;
    public Button[] minionButtons;

    [Header("Bosses UI")]
    public GameObject bossesContainer;
    public Button[] bossButtons;

    [Header("Locations UI")]
    public GameObject locationsContainer;
    public Button[] locationButtons;

    [Header("Beastiary Display UI")]
    public GameObject displayUI;
    public Image beastImage;
    public TMP_Text beastName;
    public TMP_Text beastDescription;

    #region Save File Data
    [Header("Debugging")]
    //Beastiary
    [Header("Minions")]
    //Minions
    public bool smallTyanak = false;
    public bool bigBrotherTyanak;
    public bool ponyTikbalang;
    public bool stallionTikbalang;
    public bool mananangal;
    public bool janetTheMangkukulam;
    public bool robertTheMangkukulam;
    public bool childWhiteLady;
    public bool teenagerWhiteLady;
    public bool grayHairedKapre;
    public bool redEyeKapre;
    [Header("Bosses")]
    //Bosses
    public bool infantTyanak;
    public bool theBlindTikbalang;
    public bool theMonstrousMananangal;
    public bool papaMangkukulam;
    public bool theMalevolentWhiteLady;
    public bool theBigBossKapre;
    public bool juanPusong;
    [Header("Locations")]
    //Locations
    public bool davao;
    public bool rizal;
    public bool panay;
    public bool antique;
    public bool siquijor;
    public bool baleteDrive;
    public bool cebu;
    #endregion

    private void Update()
    {
        SetButtonInteractable(minionButtons, smallTyanak, bigBrotherTyanak, ponyTikbalang, stallionTikbalang, mananangal, janetTheMangkukulam, robertTheMangkukulam, childWhiteLady, teenagerWhiteLady, grayHairedKapre, redEyeKapre);
        SetButtonInteractable(bossButtons, infantTyanak, theBlindTikbalang, theMonstrousMananangal, papaMangkukulam, theMalevolentWhiteLady, theBigBossKapre, juanPusong);
        SetButtonInteractable(locationButtons, davao, rizal, panay, antique, siquijor, baleteDrive, cebu);
    }
    private void SetButtonInteractable(Button[] buttons, params bool[] values)
    {
        if (buttons.Length != values.Length)
        {
            Debug.LogError("Mismatch between buttons and values array lengths.");
            return;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = values[i];
            Transform childLock = buttons[i].transform.Find("Lock");

            if (childLock != null)
            {
                childLock.gameObject.SetActive(!values[i]);
            }
        }
    }

    #region Save & Load
    public void LoadData(GameData data)
    {
        // Minions
        smallTyanak = data.smallTyanak;
        bigBrotherTyanak = data.bigBrotherTyanak;
        ponyTikbalang = data.ponyTikbalang;
        stallionTikbalang = data.stallionTikbalang;
        mananangal = data.mananangal;
        janetTheMangkukulam = data.janetTheMangkukulam;
        robertTheMangkukulam = data.robertTheMangkukulam;
        childWhiteLady = data.childWhiteLady;
        teenagerWhiteLady = data.teenagerWhiteLady;
        grayHairedKapre = data.grayHairedKapre;
        redEyeKapre = data.redEyeKapre;

        // Bosses
        infantTyanak = data.infantTyanak;
        theBlindTikbalang = data.theBlindTikbalang;
        theMonstrousMananangal = data.theMonstrousMananangal;
        papaMangkukulam = data.papaMangkukulam;
        theMalevolentWhiteLady = data.theMalevolentWhiteLady;
        theBigBossKapre = data.theBigBossKapre;
        juanPusong = data.juanPusong;

        // Locations
        davao = data.davao;
        rizal = data.rizal;
        panay = data.panay;
        antique = data.antique;
        siquijor = data.siquijor;
        baleteDrive = data.baleteDrive;
        cebu = data.cebu;
    }

    public void SaveData(GameData data)
    {
        
    }
    #endregion

    public void DisplayBeast(Sprite image, string name, string descrp)
    {
        beastImage.sprite = image;
        beastName.text = name;
        beastDescription.text = descrp;

        displayUI.SetActive(true);
    }
}
