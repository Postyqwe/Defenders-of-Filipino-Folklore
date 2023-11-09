using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class ItemDrop
{
    public GameObject prefab;
    public int amount = 1;
}

public class Chest : MonoBehaviour
{
    [SerializeField]
    private InputAction interactAction;

    public ItemDrop[] itemsDropPrefab;
    public Transform itemSpawnPoint;

    Animator animator;
    Collider col;
    bool isChestOpen = false;
    bool isClose = false;

    AudioManager audioManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider>();
        audioManager = FindObjectOfType<AudioManager>();

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
        if (!isChestOpen && isClose)
        {
            audioManager.playOpenChest();
            OpenChest();
        }
    }

    private void OpenChest()
    {
        animator.SetTrigger("Open");
        col.enabled = false;
        isChestOpen = true;
        isClose = false;
        UpdateUI();
    }

    public void SpawnItems()
    {
        if (itemsDropPrefab != null && itemsDropPrefab.Length > 0 && itemSpawnPoint != null)
        {
            foreach (var itemDrop in itemsDropPrefab)
            {
                int numberOfItemsToSpawn = itemDrop.amount;
                for (int i = 0; i < numberOfItemsToSpawn; i++)
                {
                    GameObject itemPrefab = itemDrop.prefab;
                    GameObject item = Instantiate(itemPrefab, itemSpawnPoint.position, Quaternion.identity);

                    Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

                    if (itemRigidbody != null)
                    {
                        float upwardForce = 5f;
                        itemRigidbody.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);

                        float scatterForce = 2f;
                        Vector3 scatterDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                        itemRigidbody.AddForce(scatterDirection * scatterForce, ForceMode.Impulse);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isClose = true;
            Debug.Log("Player close to chest");
            UpdateUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isClose = false;
            Debug.Log("Player away to chest");
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
