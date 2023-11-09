using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class First : MonoBehaviour,IDataPersistence
{
    public VideoPlayer player;
    public GameObject display;

    public AudioMixer audioMixer;

    public DemoLoadScene scene;
    bool level1;

    private bool isVideoPlaying = false;
    private float videoDuration = 17f; // Set the duration of your video in seconds

    public void LoadData(GameData data)
    {
        level1 = data.lvl1;
    }

    public void OnButtonClick()
    {
        if (!level1)
        {
            float volume = PlayerPrefs.GetFloat("sfxVolume");
            audioMixer.SetFloat("music", Mathf.Lerp(-80.0f, 0.0f, Mathf.Clamp01(0)));
            display.SetActive(true);
            player.Play();
            player.SetDirectAudioVolume(0, volume);
            StartCoroutine(WaitForVideoToFinish());
            isVideoPlaying = true;
            Debug.Log("Playing");
        }
        else
        {
            scene.LoadScene("LVL 1.1");
        }
    }

    IEnumerator WaitForVideoToFinish()
    {
        float timer = 0f;

        while (timer < videoDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        player.Stop();
        player.time = 0f;
        scene.LoadScene("LVL 1.1");
    }

    public void SaveData(GameData data)
    {
        // Save data logic
    }
}
