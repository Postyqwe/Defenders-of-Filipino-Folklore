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

    public ItemDrop[] itemsDropPrefab;
    public Transform itemSpawnPoint;

    Collider col;
    bool isClose = false;

    private void Start()
    {
        col = GetComponent<Collider>();

        if (interactAction != null)
        {
            interactAction.Enable();
            interactAction.performed += OnInteract;
        }
        else
        {
            Debug.LogError("Interact Action is not assigned. Please assign an Input Action in the Inspector.");
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (isClose)
        {
            ShowDialogue();
            
        }
    }

    private void ShowDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isClose = true;
            Debug.Log("Player close to NPC");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isClose = false;
            Debug.Log("Player away to NPC");
        }
    }
}