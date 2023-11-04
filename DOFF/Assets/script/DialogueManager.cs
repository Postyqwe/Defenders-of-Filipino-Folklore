using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public GameObject coin;

    private Queue<string> sentences;
    private string currentLanguage;
    private bool isReceived = false;
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        currentLanguage = PlayerPrefs.GetString("Language", "English");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        string[] sentencesToUse = currentLanguage == "Tagalog" ? dialogue.tagalogSentence : dialogue.englishSentence;

        foreach (string sentence in sentencesToUse)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
    }

    public void Rewarder(bool isRewarded, int amount)
    {
        if(isRewarded && !isReceived)
        {
            for(int i = 0; i < amount; i++)
            {
                Instantiate(coin, transform.position, Quaternion.identity);
                isReceived = true;
            }
        }
    }
}
