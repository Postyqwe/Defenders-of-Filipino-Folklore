using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSrouce;

    [Header("---------- Audio Clip Background ----------")]
    public AudioClip mainMenuBGM;
    public AudioClip ambience;

    [Header("---------- Audio Clip SFX ----------")]
    public AudioClip buttonSound;
    public AudioClip Attack;
    public AudioClip playerHit;
    public AudioClip playerDeath;
    public AudioClip monsterDeath;
    public AudioClip OpenChest;
    public AudioClip coinObtain;
    public AudioClip buyWeapon;
    public AudioClip monsterAttack;
    public AudioClip darkMagic;
    public AudioClip buff;
    public AudioClip slingshot;
    public AudioClip monsterHit;
    public AudioClip changeScene;




    #region Keep Audio Manager
    private static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        Debug.Log("Start method called.");
        musicSource.clip = mainMenuBGM;
        musicSource.Play();
    }
    public void SetBackgroundClip(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void SetSFXClip(AudioClip clip)
    {
        SFXSrouce.clip = clip;
        SFXSrouce.Play();
    }
    public void playMainMenuBGM()
    {
        musicSource.clip = mainMenuBGM;
        musicSource.Play();
    }
    public void playButton()
    {
        SFXSrouce.clip = buttonSound;
        SFXSrouce.Play();
    }
    public void playWeaponAttack()
    {
        SFXSrouce.clip = Attack;
        SFXSrouce.Play();
    }
    public void playPlayerHit()
    {
        SFXSrouce.clip = playerHit;
        SFXSrouce.Play();
    }
    public void playPlayerDeath()
    {
        SFXSrouce.clip = playerDeath;
        SFXSrouce.Play();
    }

    public void playMonsterDeath()
    {
        SFXSrouce.clip = monsterDeath;
        SFXSrouce.Play();
    }

    public void playOpenChest()
    {
        SFXSrouce.clip = OpenChest;
        SFXSrouce.Play();
    }

    public void playcoinObtain()
    {
        SFXSrouce.clip = coinObtain;
        SFXSrouce.Play();
    }

    public void playbuyWeapon()
    {
        SFXSrouce.clip = buyWeapon;
        SFXSrouce.Play();
    }

    public void playmonsterAttack()
    {
        SFXSrouce.clip = monsterAttack;
        SFXSrouce.Play();
    }

    public void playdarkMagic()
    {
        SFXSrouce.clip = darkMagic;
        SFXSrouce.Play();
    }


    public void playbuff()
    {
        SFXSrouce.clip = buff;
        SFXSrouce.Play();
    }

    public void playslingshot()
    {
        SFXSrouce.clip = slingshot;
        SFXSrouce.Play();
    }

    public void playambience()
    {
        SFXSrouce.clip = ambience;
        SFXSrouce.Play();
    }

    public void playmonsterHit()
    {
        SFXSrouce.clip = monsterHit;
        SFXSrouce.Play();
    }

    public void playchangeScene()
    {
        SFXSrouce.clip = changeScene;
        SFXSrouce.Play();
    }

}
