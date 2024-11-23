using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance; // Singleton instance
    public List<Quest> allQuests = new List<Quest>(); // List of all quests
    public List<Quest> activeQuests = new List<Quest>(); // List of active quests

    private int currentQuestIndex = 0; // Track the current quest

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Create singleton instance
        }
        else
        {
            Destroy(gameObject); // Avoid duplicates
        }
    }

    void Start()
    {
        // Quest 1: "The Introduction"
        Quest introQuest = new Quest(
            "The Introduction",
            "Meet with the head of the construction department. He’s willing to 'assist' with your future projects for a price.",
            100, 10); // 100 resources, +10 reputation with local business leaders
        allQuests.Add(introQuest);

        // Quest 2: "Covering Tracks"
        Quest coveringTracksQuest = new Quest(
            "Covering Tracks",
            "Someone is leaking information about your financial 'mismanagement.' Pay off the journalist to ensure it stays hidden.",
            -50, 5); // -50 resources, +5 reputation with media and +5 reputation with citizens
        allQuests.Add(coveringTracksQuest);

        // Quest 3: "Water Crisis"
        Quest waterCrisisQuest = new Quest(
            "Water Crisis",
            "The town's reservoirs are nearly empty, and people are rioting. Use your resources to fund a temporary solution, or let things worsen and face the consequences.",
            -100, 20); // -100 resources, +20 reputation with citizens
        allQuests.Add(waterCrisisQuest);

        // Quest 4: "Bribe the Media"
        Quest bribeTheMediaQuest = new Quest(
            "Bribe the Media",
            "The local media outlet is asking too many questions. Pay off the editor and make sure they run favorable stories about your administration.",
            -75, 15); // -75 resources, +15 reputation with media
        allQuests.Add(bribeTheMediaQuest);

        // Quest 5: "The Election Looms"
        Quest electionLoomsQuest = new Quest(
            "The Election Looms",
            "Rig the local elections by influencing key figures in the voting system. Make sure your re-election is guaranteed.",
            -150, 30); // -150 resources, +30 reputation with business
        allQuests.Add(electionLoomsQuest);

        // Quest 6: "Environmental Scandal"
        Quest environmentalScandalQuest = new Quest(
            "Environmental Scandal",
            "A project to build luxury hotels on the coastline has destroyed part of the local ecosystem. Silence the environmental agency or risk losing your influence with the public.",
            -120, 15); // -120 resources, +15 reputation with business
        allQuests.Add(environmentalScandalQuest);

       
        // Quest 8: "Final Power Grab"
        Quest finalPowerGrabQuest = new Quest(
            "Final Power Grab",
            "Your enemies are circling, and your hold on power is slipping. Use your accumulated wealth and influence to consolidate your position or be forced out.",
            -200, 50); // -200 resources, +50 reputation across citizens, media, and business
        allQuests.Add(finalPowerGrabQuest);

        // Activate the first quest
        ActivateQuest(currentQuestIndex);
    }

    // Activate a quest by index
    public void ActivateQuest(int questIndex)
    {
        if (questIndex < allQuests.Count)
        {
            Quest quest = allQuests[questIndex];
            activeQuests.Add(quest);
            Debug.Log("Activated Quest: " + quest.questName);
        }
    }

    // Complete a quest and proceed to the next
    public void CompleteQuest(string questName)
    {
        Quest quest = activeQuests.Find(q => q.questName == questName);
        if (quest != null && !quest.isCompleted)
        {
            quest.CompleteQuest();
            Debug.Log("Quest Completed: " + quest.questName);
            ProceedToNextQuest(); // Move to the next quest after completing the current one
        }
    }

    // Proceed to the next quest after completing the current one
    void ProceedToNextQuest()
    {
        currentQuestIndex++;
        if (currentQuestIndex < allQuests.Count)
        {
            ActivateQuest(currentQuestIndex); // Activate the next quest
        }
        else
        {
            Debug.Log("All quests completed!");
        }
    }

    // Fail a quest and apply reputation loss
    void FailQuest(string questName, int reputationLoss)
    {
        Quest quest = activeQuests.Find(q => q.questName == questName);
        if (quest != null && !quest.isCompleted)
        {
            PlayerReputation.instance.ChangeReputation(-reputationLoss); // Apply reputation loss
            Debug.Log("Failed quest: " + questName + " - Lost " + reputationLoss + " reputation");
        }
    }
}
