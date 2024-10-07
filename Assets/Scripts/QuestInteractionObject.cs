using UnityEngine;

public class QuestInteractionObject : MonoBehaviour, IInteractable
{
    public string questToComplete; // The quest that will be completed upon interaction

    public void Interact()
    {
        // Complete the associated quest
        QuestManager.instance.CompleteQuest(questToComplete);
        Debug.Log("Completed quest: " + questToComplete);

        // You can destroy or deactivate the object after interaction
        //Destroy(gameObject);
    }
}
