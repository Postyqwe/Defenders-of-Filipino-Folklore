using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BestiaryList
{
    smallTyanak,
    bigBrotherTyanak,
    ponyTikbalang,
    stallionTikbalang,
    mananangal,
    janetTheMangkukulam,
    robertTheMangkukulam,
    childWhiteLady,
    teenagerWhiteLady,
    grayHairedKapre,
    redEyeKapre,

    infantTyanak,
    theBlindTikbalang,
    theMonstrousMananangal,
    papaMangkukulam,
    theMalevolentWhiteLady,
    theBigBossKapre,
    juanPusong,

    davao,
    rizal,
    panay,
    antique,
    siquijor,
    baleteDrive
}
public class SaveKill : MonoBehaviour, IDataPersistence
{
    #region Save File Data
    //Minions
    private bool smallTyanak;
    private bool bigBrotherTyanak;
    private bool ponyTikbalang;
    private bool stallionTikbalang;
    private bool mananangal;
    private bool janetTheMangkukulam;
    private bool robertTheMangkukulam;
    private bool childWhiteLady;
    private bool teenagerWhiteLady;
    private bool grayHairedKapre;
    private bool redEyeKapre;
    //Bosses
    private bool infantTyanak;
    private bool theBlindTikbalang;
    private bool theMonstrousMananangal;
    private bool papaMangkukulam;
    private bool theMalevolentWhiteLady;
    private bool theBigBossKapre;
    private bool juanPusong;
    //Locations
    private bool davao;
    private bool rizal;
    private bool panay;
    private bool antique;
    private bool siquijor;
    private bool baleteDrive;
    #endregion
    public BestiaryList bestiaryList;

    private void Start()
    {
    }
    public void LoadData(GameData data)
    {

    }

    public void SaveData(GameData data)
    {
        switch (bestiaryList)
        {
            case BestiaryList.smallTyanak:
                data.smallTyanak = smallTyanak;
                break;
            case BestiaryList.bigBrotherTyanak:
                data.bigBrotherTyanak = bigBrotherTyanak;
                break;
            case BestiaryList.ponyTikbalang:
                data.ponyTikbalang = ponyTikbalang;
                break;
            case BestiaryList.stallionTikbalang:
                data.stallionTikbalang = stallionTikbalang;
                break;
            case BestiaryList.mananangal:
                data.mananangal = mananangal;
                break;
            case BestiaryList.janetTheMangkukulam:
                data.janetTheMangkukulam = janetTheMangkukulam;
                break;
            case BestiaryList.robertTheMangkukulam:
                data.robertTheMangkukulam = robertTheMangkukulam;
                break;
            case BestiaryList.childWhiteLady:
                data.childWhiteLady = childWhiteLady;
                break;
            case BestiaryList.teenagerWhiteLady:
                data.teenagerWhiteLady = teenagerWhiteLady;
                break;
            case BestiaryList.grayHairedKapre:
                data.grayHairedKapre = grayHairedKapre;
                break;
            case BestiaryList.redEyeKapre:
                data.redEyeKapre = redEyeKapre;
                break;
            
            case BestiaryList.davao:
                data.davao = davao;
                break;
            case BestiaryList.rizal:
                data.rizal = rizal;
                break;
            case BestiaryList.panay:
                data.panay = panay;
                break;
            case BestiaryList.antique:
                data.antique = antique;
                break;
            case BestiaryList.siquijor:
                data.siquijor = siquijor;
                break;
            case BestiaryList.baleteDrive:
                data.baleteDrive = baleteDrive;
                break;
        }
    }
}
