using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image[] images;
    public Button nextButton;
    public Button prevButton;
    public Button exitButton;
    public GameObject tutorialButton;

    public Image imageComponent; // Assign this in the Inspector

    private int currentIndex = 0;

    private void Start()
    {
        ShowHideButtons();
        UpdateImage();
    }

    public void NextImage()
    {
        currentIndex++;
        ShowHideButtons();
        UpdateImage();
    }

    public void PrevImage()
    {
        currentIndex--;
        ShowHideButtons();
        UpdateImage();
    }

    public void ExitTutorial()
    {
        // Add logic to close or hide the tutorial
        tutorialButton.SetActive(false); // For example, just hide the GameObject
    }

    private void UpdateImage()
    {
        if (currentIndex >= 0 && currentIndex < images.Length)
        {
            // Set the sprite based on the current index
            imageComponent.sprite = images[currentIndex].sprite;
        }
    }

    private void ShowHideButtons()
    {
        if (currentIndex <= 0)
        {
            prevButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
        }
        else
        {
            prevButton.gameObject.SetActive(true);
        }

        if (currentIndex >= images.Length - 1)
        {
            nextButton.interactable = false;
            exitButton.gameObject.SetActive(true);
        }
        else
        {
            nextButton.interactable = true;
        }
    }
}
