using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public Quest q_Purple;
    public Quest q_Children;
    //public Quest q_Blue;
    //public Quest q_LostMoney;
    //public Quest q_Colors;
    [SerializeField] Canvas questMenu;
    [SerializeField] TMP_Text questMenuText;
    [SerializeField] List<Quest> questList;
    private void Awake()
    {
        questMenu = gameObject.GetComponentInChildren<Canvas>();
        questMenuText = questMenu.GetComponentInChildren<TMP_Text>();
    }
    private void Start()
    {
        MakeQuest   (q_Purple, "Get Into The Purple Neighborhood", "You want to get into the purple neighborhood, " + 
                    "the guard will let you in if you LOOK purple.");
        MakeQuest   (q_Children, "Lost Children", "The concerned couple asked you to find their children. This town is small, " +
                    "I bet you'll find them around here.");
        //MakeQuest   (q_Blue)
        //MakeQuest   (q_LostMoney)
        //MakeQuest   (q_Colors)
        questMenu.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowQuestMenu();
        }
    }
    private void MakeQuest(Quest quest, string questName, string questInfo)
    {
        quest.questName = questName;
        quest.questInfo = questInfo;
        quest.questCompleted = false;
        questList.Add(quest);
    }
    private void ShowQuestMenu()
    {
        if(questMenu.gameObject.active == true)
        {
            questMenu.gameObject.SetActive(false);
        }
        else
        {
            questMenu.gameObject.SetActive(true);
            RefreshQuestMenu();
        }
    }
    public void RefreshQuestMenu()
    {
        questMenuText.text = "";
        foreach (Quest quest in questList)
        {
            if(quest.questActive == true)
            {
                questMenuText.text += quest.questName + ": \n" + quest.questInfo + "\n";
            }
        }
    }
}
