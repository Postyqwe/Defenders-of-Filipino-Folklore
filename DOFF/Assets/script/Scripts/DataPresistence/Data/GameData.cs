 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public bool isTutorialFinished;

    //level
    public int healthLevel;
    public int speedLevel;

    //coins
    public int coins;

    //Story
    public bool lvl1;
    public bool lvl2;
    public bool lvl3;
    public bool lvl4;
    public bool lvl5;
    public bool lvl6;
    public bool lvl7;

    //Achievement
    public bool ach1;
    public bool ach2;
    public bool ach3;
    public bool ach4;
    public bool ach5;
    public bool ach6;
    public bool ach7;
    public int killedTyanak;
    public int killedTikbalang;
    public int killedMananangal;
    public int killedMangkukulam;
    public int killedWhiteLady;
    public int killedKapre;
    public int killedFinalBoss;
    //Beastiary
    //Minions
    public bool smallTyanak;
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
    //Bosses
    public bool infantTyanak;
    public bool theBlindTikbalang;
    public bool theMonstrousMananangal;
    public bool papaMangkukulam;
    public bool theMalevolentWhiteLady;
    public bool theBigBossKapre;
    public bool juanPusong;
    //Locations
    public bool davao;
    public bool rizal;
    public bool panay;
    public bool antique;
    public bool siquijor;
    public bool baleteDrive;

    //shop items
    //Melee
    public bool hasMoroBarong;
    public bool hasKriss;
    public bool hasBolo;
    public bool hasTaga;
    public bool hasHanger;
    public bool hasWalisTambo;
    //Range
    public bool hasHandgun;
    public bool hasSlingShot;
    public bool hasBakya;
    public bool hasDyaryo;
    //Magic
    public bool hasMagicWand;
    public bool hasMagicOrb;


    public GameData()
    {
        this.healthLevel = 0;
        this.speedLevel = 0;

        this.coins = 0;

        this.isTutorialFinished = false;

        //Story
        this.lvl1 = false;
        this.lvl2 = false;
        this.lvl3 = false;
        this.lvl4 = false;
        this.lvl5 = false;
        this.lvl6 = false;
        this.lvl7 = false;
        //Achiev
        this.ach1 = false;
        this.ach2 = false;
        this.ach3 = false;
        this.ach4 = false;
        this.ach5 = false;
        this.ach6 = false;
        this.ach7 = false;

        this.killedTyanak = 0;
        this.killedTikbalang = 0;
        this.killedMananangal = 0;
        this.killedMangkukulam = 0;
        this.killedWhiteLady = 0;
        this.killedKapre = 0;
        this.killedFinalBoss = 0;

        //Beastiary
        // Minions
        this.smallTyanak = false;
        this.bigBrotherTyanak = false;
        this.ponyTikbalang = false;
        this.stallionTikbalang = false;
        this.mananangal = false;
        this.janetTheMangkukulam = false;
        this.robertTheMangkukulam = false;
        this.childWhiteLady = false;
        this.teenagerWhiteLady = false;
        this.grayHairedKapre = false;
        this.redEyeKapre = false;
        // Bosses
        this.infantTyanak = false;
        this.theBlindTikbalang = false;
        this.theMonstrousMananangal = false;
        this.papaMangkukulam = false;
        this.theMalevolentWhiteLady = false;
        this.theBigBossKapre = false;
        this.juanPusong = false;
        // Locations
        this.davao = false;
        this.rizal = false;
        this.panay = false;
        this.antique = false;
        this.siquijor = false;
        this.baleteDrive = false;

        //Shop
        this.hasMoroBarong = false;
        this.hasKriss = false;
        this.hasBolo = false;
        this.hasTaga = true;
        this.hasHanger = false;
        this.hasWalisTambo = false;
        this.hasHandgun = false;
        this.hasSlingShot = false;
        this.hasBakya = false;
        this.hasDyaryo = false;
        this.hasMagicWand = false;
        this.hasMagicOrb = false;
    }
}
