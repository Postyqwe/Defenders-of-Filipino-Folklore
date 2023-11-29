using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class bossesCutscene : MonoBehaviour
{
    public VideoPlayer player;
    public GameObject activate;
    public GameObject interact;
    public GameObject attack;

    public AudioMixer audioMixer;

    private bool isVideoPlaying = false;
    public float videoDuration = 17f; // Set the duration of your video in seconds

    private void Start()
    {

        float volume = PlayerPrefs.GetFloat("sfxVolume");
        audioMixer.SetFloat("music", Mathf.Lerp(-80.0f, 0.0f, Mathf.Clamp01(0)));
        player.Play();
        player.SetDirectAudioVolume(0, volume);
        StartCoroutine(WaitForVideoToFinish());
        isVideoPlaying = true;
        Debug.Log("Playing");
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
        activate.SetActive(false);
        interact.SetActive(false);
        attack.SetActive(true);
    }
}
