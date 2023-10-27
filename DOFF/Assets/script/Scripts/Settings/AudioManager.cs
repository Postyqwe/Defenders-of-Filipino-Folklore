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

    [Header("---------- Audio Clip SFX ----------")]

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
}
