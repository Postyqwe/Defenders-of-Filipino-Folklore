using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossList
{
    None,
    infantTyanak,
    theBlindTikbalang,
    theMonstrousMananangal,
    papaMangkukulam,
    theMalevolentWhiteLady,
    theBigBossKapre,
    juanPusong,
}
public class SaveBoss : MonoBehaviour,IDataPersistence
{
    public BossList bossList;

    private bool infantTyanak;
    private bool theBlindTikbalang;
    private bool theMonstrousMananangal;
    private bool papaMangkukulam;
    private bool theMalevolentWhiteLady;
    private bool theBigBossKapre;
    private bool juanPusong;

    public void Save()
    {
        DataPersistenceManager.instance.SaveGame();
    }

    public void LoadData(GameData data)
    {

    }

    public void SaveData(GameData data)
    {
        switch (bossList)
        {
            case BossList.infantTyanak:
                data.infantTyanak = true;
                data.killedTyanak += 1;
                break;
            case BossList.theBlindTikbalang:
                data.theBlindTikbalang = true;
                data.killedTikbalang += 1;
                break;
            case BossList.theMonstrousMananangal:
                data.theMonstrousMananangal = true;
                data.killedMananangal += 1;
                break;
            case BossList.papaMangkukulam:
                data.papaMangkukulam = true;
                data.killedMangkukulam += 1;
                break;
            case BossList.theMalevolentWhiteLady:
                data.theMalevolentWhiteLady = true;
                data.killedWhiteLady += 1;
                break;
            case BossList.theBigBossKapre:
                data.theBigBossKapre = true;
                data.killedKapre += 1;
                break;
            case BossList.juanPusong:
                data.juanPusong = true;
                data.killedFinalBoss += 1;
                break;
        }
    }
}
