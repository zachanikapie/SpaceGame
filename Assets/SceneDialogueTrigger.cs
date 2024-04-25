using UnityEngine;
using TMPro;

public class SceneDialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager; // Reference to the DialogueManager script

    void Start()
    {
        // Start dialogue when the scene loads
        dialogueManager.StartDialogue(new string[] { " Hey, this is a warning! Be careful...", "Press Spa'E' to continue." });
    }
}
