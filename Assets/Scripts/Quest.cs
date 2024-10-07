using UnityEngine; // This line is needed to access Unity-specific functions

public class Quest
{
    public string questName;
    public string description;
    public bool isCompleted;
    public int resourceReward;
    public int reputationReward;

    // Constructor to define quests
    public Quest(string name, string desc, int resource, int reputation)
    {
        questName = name;
        description = desc;
        resourceReward = resource;
        reputationReward = reputation;
        isCompleted = false;
    }

    // Mark the quest as complete and give rewards
    public void CompleteQuest()
    {
        if (!isCompleted)
        {
            isCompleted = true;
            PlayerResources.instance.AddResource(resourceReward);
            PlayerReputation.instance.ChangeReputation(reputationReward);
            Debug.Log("Quest Completed: " + questName); // This line requires UnityEngine
        }
    }

    public void UpdateQuestDescription(string newDescription)
    {
        this.description = newDescription; // Update the quest's description dynamically
        Debug.Log("Quest updated: " + questName + " - " + description);
    }

}
