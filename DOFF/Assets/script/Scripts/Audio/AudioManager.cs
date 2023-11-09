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
    public AudioClip dexterDeath;
    public AudioClip dexterHit;
    public AudioClip dexterAttack;

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
        SFXSrouce.PlayOneShot(buttonSound);
    }

    public void playWeaponAttack()
    {
        SFXSrouce.PlayOneShot(Attack);
    }

    public void playPlayerHit()
    {
        SFXSrouce.PlayOneShot(playerHit);
    }

    public void playPlayerDeath()
    {
        SFXSrouce.PlayOneShot(playerDeath);
    }

    public void playMonsterDeath()
    {
        SFXSrouce.PlayOneShot(monsterDeath);
    }

    public void playOpenChest()
    {
        SFXSrouce.PlayOneShot(OpenChest);
    }

    public void playcoinObtain()
    {
        SFXSrouce.PlayOneShot(coinObtain);
    }

    public void playbuyWeapon()
    {
        SFXSrouce.PlayOneShot(buyWeapon);
    }

    public void playmonsterAttack()
    {
        SFXSrouce.PlayOneShot(monsterAttack);
    }

    public void playdarkMagic()
    {
        SFXSrouce.PlayOneShot(darkMagic);
    }

    public void playbuff()
    {
        SFXSrouce.PlayOneShot(buff);
    }

    public void playslingshot()
    {
        SFXSrouce.PlayOneShot(slingshot);
    }

    public void playambience()
    {
        SFXSrouce.PlayOneShot(ambience);
    }

    public void playmonsterHit()
    {
        SFXSrouce.PlayOneShot(monsterHit);
    }

    public void playchangeScene()
    {
        SFXSrouce.PlayOneShot(changeScene);
    }

    public void playerDexterAttack()
    {
        SFXSrouce.PlayOneShot(dexterAttack);
    }
    public void playerDexterHit()
    {
        SFXSrouce.PlayOneShot(dexterHit);
    }
    public void playDexterDeath()
    {
        SFXSrouce.PlayOneShot(dexterDeath);
    }
}
