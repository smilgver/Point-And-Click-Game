using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue questDialogue;
    public Dialogue finalDialogue;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] bool npcHasQuest = false; // does this NPC have a quest to give to the player? if so, i will change the value
                                               // to true in the editor.
    [SerializeField] bool npcQuestFinished = false; // did the player finish this NPCs quest.
    [SerializeField] bool finalNPC_Dialogue = false; // should the NPC display their final dialogue.

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TriggerDialogue();
            
        }
    }

    public void TriggerDialogue()
    {
        if (dialogueManager.playerInQuest && npcQuestFinished)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(questDialogue);
            dialogueManager.playerInQuest = false;
        }
        else if (npcQuestFinished)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(finalDialogue);
        }
        else if (!dialogueManager.playerInQuest)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            if (npcHasQuest)
            {
                dialogueManager.playerInQuest = true;
            }
        }
        else if (!npcHasQuest)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
