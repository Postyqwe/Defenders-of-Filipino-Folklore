using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeastiaryButton : MonoBehaviour
{
    public BeastiarySO BSO;
    BeastiaryManager beastiaryManager;

    private void Start()
    {
        beastiaryManager = FindAnyObjectByType<BeastiaryManager>();
        Transform iconEnemy = transform.Find("IconEnemy");
        Image iconImage = iconEnemy.GetComponent<Image>();
        iconImage.sprite = BSO.beastImage;
    }

    public void OnButtonClick()
    {
        if (BSO != null)
        {
            beastiaryManager.DisplayBeast(BSO.beastImage, BSO.beastName, BSO.beastDescription);
        }
        else
        {
            Debug.Log("No Scriptabble Object");
        }
    }
}
