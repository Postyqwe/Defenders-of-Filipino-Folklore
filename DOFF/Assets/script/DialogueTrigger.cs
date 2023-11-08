using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField]
    private InputAction interactAction;

    [Header("Coin Giver")]
    public bool isCoinGiver;
    public int amount;

    [Header("Cutscene")]
    public bool isCutScene;
    public GameObject SceneTrigger;

    Collider col;
    bool isClose = false;

    private void Start()
    {

        col = GetComponent<Collider>();

        if (interactAction != null)
        {
            interactAction.Enable();
            interactAction.performed += _ => OnInteract();
        }
        else
        {
            Debug.LogError("Interact Action is not assigned. Please assign an Input Action in the Inspector.");
        }
    }

    private void OnInteract()
    {
        if (isClose)
        {
            ShowDialogue();
            
        }
    }

    private void ShowDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().Rewarder(isCoinGiver, amount);
        FindObjectOfType<DialogueManager>().Cutscene(isCutScene, SceneTrigger);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isClose = true;
            Debug.Log("Player close to NPC");
            UpdateUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isClose = false;
            Debug.Log("Player away to NPC");
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameController != null)
        {
            Transform attackUI = gameController.transform.Find("Attack");
            Transform interactUI = gameController.transform.Find("Interact");

            if (attackUI != null && interactUI != null)
            {
                attackUI.gameObject.SetActive(!isClose);
                interactUI.gameObject.SetActive(isClose);
            }
        }
    }
}