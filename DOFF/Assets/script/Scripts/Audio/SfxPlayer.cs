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
    public void playOpenChest()
    {
        FindObjectOfType<AudioManager>().playOpenChest();
    }
    public void playcoinObtain()
    {
        FindObjectOfType<AudioManager>().playcoinObtain();
    }
    public void playbuyWeapon()
    {
        FindObjectOfType<AudioManager>().playbuyWeapon();
    }
    public void playmonsterAttack()
    {
        FindObjectOfType<AudioManager>().playmonsterAttack();
    }
    public void playdarkMagic()
    {
        FindObjectOfType<AudioManager>().playdarkMagic();
    }
    public void playdarkMagic()
    {
        FindObjectOfType<AudioManager>().playbuff();
    }
    public void playslingshot()
    {
        FindObjectOfType<AudioManager>().playslingshot();
    }
    public void playambience()
    {
        FindObjectOfType<AudioManager>().playambience();
    }
    public void playmonsterHit()
    {
        FindObjectOfType<AudioManager>().playmonsterHit();
    }
    public void playchangeScene()
    {
        FindObjectOfType<AudioManager>().playchangeScene();
    }

}
