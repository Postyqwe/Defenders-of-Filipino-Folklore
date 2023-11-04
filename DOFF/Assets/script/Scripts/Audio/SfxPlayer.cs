using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    public void SFXPlay(AudioClip clip)
    {
        FindObjectOfType<AudioManager>().SetSFXClip(clip);
    }

    public void playButton()
    {
        FindObjectOfType<AudioManager>().playButton();
    }

    public void playPlayerHit()
    {
        FindObjectOfType<AudioManager>().playPlayerHit();
    }

    public void playPlayerDeath()
    {
        FindObjectOfType<AudioManager>().playPlayerDeath();
    }
    public void playPlayerAttack()
    {
        FindObjectOfType<AudioManager>().playWeaponAttack();
    }
    public void playMonsterDeath()
    {
        FindObjectOfType<AudioManager>().playMonsterDeath();
    }
}
