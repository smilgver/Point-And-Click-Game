using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> questSentences;

    [SerializeField] GameObject canvasParent;
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Text NPC_Name;
    [SerializeField] TMP_Text NPC_Dialogue;
    [SerializeField] Button continuteConvButton;
    [SerializeField] Button endConvButton;
    [SerializeField] Button questButton;
    [SerializeField] bool playerInConversation = false;
    public bool playerInQuest = false;

    void Start()
    {
        sentences = new Queue<string>();

        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Canvas>();
        NPC_Name = GameObject.FindGameObjectWithTag("CanvasNPC_Name").GetComponent<TMP_Text>();
        NPC_Dialogue = GameObject.FindGameObjectWithTag("CanvasNPC_Dialogue").GetComponent<TMP_Text>();
        continuteConvButton = GameObject.FindGameObjectWithTag("CanvasNPC_ContButton").GetComponent<Button>();
        endConvButton = GameObject.FindGameObjectWithTag("CanvasNPC_EndButton").GetComponent<Button>();
        questButton = GameObject.FindGameObjectWithTag("CanvasNPC_QuestButton").GetComponent<Button>();
        continuteConvButton.onClick.AddListener(DisplayNextSentence);
        endConvButton.onClick.AddListener(EndDialogue);
        //questButton.onClick.AddListener( QUEST METHOD );


        canvas.gameObject.SetActive(false);


    }

    public void StartDialogue(Dialogue dialogue)
    {
        canvas.gameObject.SetActive(true);
        playerInConversation = true;
        NPC_Name.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
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
        StartCoroutine(AnimateText(sentence));
    }

    IEnumerator AnimateText(string sentence) //Animates the text on the screen slowly.
    {
        NPC_Dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            NPC_Dialogue.text += letter;
            yield return new WaitForSeconds(.03f);
        }
    }

    public void EndDialogue()
    {
        canvas.gameObject.SetActive(false);
        playerInConversation = false;
    }

    public bool PlayerInConversation
    {
        get { return playerInConversation; }
    }
}
