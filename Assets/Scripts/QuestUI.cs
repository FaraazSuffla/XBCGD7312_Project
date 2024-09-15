using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Text questListText; // Reference to the UI Text component for displaying quests

    private void Update()
    {
        ShowQuests(); // Continuously update the UI with the latest quest information
    }

    // Display detailed information about active and completed quests
    void ShowQuests()
    {
        questListText.text = ""; // Clear the text each frame

        // Loop through each active quest in the QuestManager
        foreach (Quest quest in QuestManager.instance.activeQuests)
        {
            // Show the quest name
            questListText.text += "<b>Quest: " + quest.questName + "</b>\n";

            // Show the quest description
            questListText.text += "Objective: " + quest.description + "\n";

            // Show the status of the quest (In Progress or Completed)
            questListText.text += "Status: " + (quest.isCompleted ? "<color=green>Completed</color>" : "<color=yellow>In Progress</color>") + "\n";

            // Show the rewards or losses
            questListText.text += "Reward: " + quest.resourceReward + " Resources, " + quest.reputationReward + " Reputation\n";
            questListText.text += "\n"; // Add spacing between quests
        }
    }
}
