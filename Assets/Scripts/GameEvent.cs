using UnityEngine;

[System.Serializable]
public class GameEvent
{
    public string eventName; // Name of the event
    public string eventDescription; // Description of the event
    public int resourceCost; // Cost of handling the event
    public int reputationEffect; // Reputation effect of handling the event

    public void TriggerEvent()
    {
        // Show the event UI and pass the event details to it
        EventUIManager.instance.ShowEventPanel(this);
    }

    // Method called when the player chooses to handle the event
    public void HandleEvent()
    {
        // Deduct resources
        PlayerResources.instance.UseResource(resourceCost);

        // Apply reputation effect
        PlayerReputation.instance.ChangeReputation(reputationEffect);

        // Hide the event UI after handling the event
        EventUIManager.instance.HideEventPanel();

        Debug.Log($"Handled event: {eventName}. Resources spent: {resourceCost}, Reputation change: {reputationEffect}");
    }

    // Method called if the player ignores the event (optional consequences)
    public void IgnoreEvent()
    {
        EventUIManager.instance.HideEventPanel();
        Debug.Log($"Ignored event: {eventName}");
    }
}
