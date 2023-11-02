using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinionList
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
}
public class SaveMinion : MonoBehaviour, IDataPersistence
{
    public MinionList minionList;

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

    void Start()
    {
        DataPersistenceManager.instance.SaveGame();
    }

    public void LoadData(GameData data)
    {

    }

    public void SaveData(GameData data)
    {

        switch (minionList)
        {
            case MinionList.smallTyanak:
                data.smallTyanak = true;
                data.killedTyanak += 1;
                break;
            case MinionList.bigBrotherTyanak:
                data.bigBrotherTyanak = true;
                data.killedTyanak += 1;
                break;
            case MinionList.ponyTikbalang:
                data.ponyTikbalang = true;
                data.killedTikbalang += 1;
                break;
            case MinionList.stallionTikbalang:
                data.stallionTikbalang = true;
                data.killedTikbalang += 1;
                break;
            case MinionList.mananangal:
                data.mananangal = true;
                data.killedMananangal += 1;
                break;
            case MinionList.janetTheMangkukulam:
                data.janetTheMangkukulam = true;
                data.killedMangkukulam += 1;
                break;
            case MinionList.robertTheMangkukulam:
                data.robertTheMangkukulam = true;
                data.killedMangkukulam += 1;
                break;
            case MinionList.childWhiteLady:
                data.childWhiteLady = true;
                data.killedWhiteLady += 1;
                break;
            case MinionList.teenagerWhiteLady:
                data.teenagerWhiteLady = true;
                data.killedWhiteLady += 1;
                break;
            case MinionList.grayHairedKapre:
                data.grayHairedKapre = true;
                data.killedKapre += 1;
                break;
            case MinionList.redEyeKapre:
                data.redEyeKapre = true;
                data.killedKapre += 1;
                break;
        }
    }
}