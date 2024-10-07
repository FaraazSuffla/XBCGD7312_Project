using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Text questListText; // Reference to the UI Text component

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
            // Format the quest name in bold
            questListText.text += "<b><size=18>Quest: " + quest.questName + "</size></b>\n";

            // Show the quest description in a smaller font
            questListText.text += "<i>Objective:</i> " + quest.description + "\n";

            // Show the status of the quest (In Progress or Completed) with color
            questListText.text += "Status: " + (quest.isCompleted ? "<color=green>Completed</color>" : "<color=yellow>In Progress</color>") + "\n";

            // Show the rewards (resources and reputation) in bold
            questListText.text += "<b>Reward: " + quest.resourceReward + " Resources, " + quest.reputationReward + " Reputation</b>\n";

            questListText.text += "\n"; // Add spacing between quests
        }
    }
}
