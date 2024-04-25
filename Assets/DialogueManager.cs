using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Reference to the TMP text element for displaying dialogue
    public GameObject enemySpawner; // Reference to the EnemySpawner GameObject
    public float typingSpeed = 0.1f; // Speed at which characters appear

    private string currentSentence; // Current sentence being displayed
    private bool isTyping; // Flag to indicate if text is currently being typed

    void Start()
    {
        // Disable the enemy spawner at the start
        enemySpawner.SetActive(false);
    }

    // Start dialogue automatically when the scene loads
    public void StartDialogue(string[] sentences)
    {
        StartCoroutine(TypeDialogue(sentences));
    }

    // Type out dialogue
    IEnumerator TypeDialogue(string[] sentences)
    {
        foreach (string sentence in sentences)
        {
            currentSentence = sentence;
            dialogueText.text = "You dumb! :p";

            // Type out each character of the sentence
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            // Wait for player input or set duration before showing the next sentence
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); // Wait for Space key
        }

        // End of dialogue
        EndDialogue();
    }

    // End dialogue
    void EndDialogue()
    {
        dialogueText.text = "See ya...";

        // Enable the enemy spawner at the end
        enemySpawner.SetActive(true);
    }
}
