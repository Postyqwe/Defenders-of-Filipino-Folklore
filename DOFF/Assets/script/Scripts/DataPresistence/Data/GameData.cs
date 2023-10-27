 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public bool isTutorialFinished;

    //Story -Lapu Lapu-
    public bool lapuChapter1Finished;
    public bool lapuChapter2Finished;
    public bool lapuChapter3Finished;
    public bool lapuChapter4Finished;

    //Story -Andres-
    public bool andresChapter1Finished;
    public bool andresChapter2Finished;
    public bool andresChapter3Finished;
    public bool andresChapter4Finished;
    public bool andresChapter5Finished;

    //coins
    public int coins;

    //Characters
    public bool isAndresUnlocked;

    //PinoyPedia
    //pickups
    public bool Palabok;
    public bool Pancit;
    public bool Sinigang;
    public bool Adobo;
    public bool Lechon;
    public bool Tinola;
    public bool KareKare;
    public bool Lugaw;
    public bool Sopas;
    public bool Champorado;
    public bool HaloHalo;
    public bool Balut;
    public bool Puto;
    public bool Bibingka;
    public bool Taho;
    public bool Sisig;
    public bool Laing;
    public bool Longganisa;

    public bool Balisong;
    public bool Kris;
    public bool Bolo;
    public bool Arnis;
    public bool Barong;
    public bool Punyal;
    public bool Sundang;
    public bool Kampilan;

    public GameData()
    {
        this.coins = 0;

        this.isAndresUnlocked = false;

        //pickups
        this.Palabok = false;
        this.Pancit = false;
        this.Sinigang = false;
        this.Adobo = false;
        this.Lechon = false;
        this.Tinola = false;
        this.KareKare = false;
        this.Lugaw = false;
        this.Sopas = false;
        this.Champorado = false;
        this.HaloHalo = false;
        this.Balut = false;
        this.Puto = false;
        this.Bibingka = false;
        this.Taho = false;
        this.Sisig = false;
        this.Laing = false;
        this.Longganisa = false;

        //weapons
        this.Balisong = false;
        this.Kris = false;
        this.Bolo = false;
        this.Barong = false;
        this.Punyal = false;
        this.Sundang = false;
        this.Kampilan = false;
        this.Arnis = false;

        this.isTutorialFinished = false;

        //story
        this.lapuChapter1Finished = false;
        this.lapuChapter2Finished = false;
        this.lapuChapter3Finished = false;
        this.lapuChapter4Finished = false;

        this.andresChapter1Finished = false;
        this.andresChapter2Finished = false;
        this.andresChapter3Finished = false;
        this.andresChapter4Finished = false;
        this.andresChapter5Finished = false;
    }
}
