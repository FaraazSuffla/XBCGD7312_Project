using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionMaking : MonoBehaviour, IInteractable
{
    public int resourceCost = 20;
    public string decisionMessage = "You decided to cover up a scandal.";
    public int reputationChange = 10;

    public GameObject decisionUIPanel; // Reference to the decision UI panel
    public Text decisionUIText; // Reference to the text component in the UI

    private void Start()
    {
        decisionUIPanel.SetActive(false); // Hide the panel by default
    }

    public void Interact()
    {
        if (PlayerResources.instance.currentResources >= resourceCost)
        {
            // Show the decision UI panel
            decisionUIPanel.SetActive(true);
            decisionUIText.text = decisionMessage;
        }
        else
        {
            Debug.Log("Not enough resources to make this decision.");
        }
    }

    // Call this method when the player confirms the decision
    public void ConfirmDecision()
    {
        // Deduct the resource cost
        PlayerResources.instance.UseResource(resourceCost);

        // Apply the decision effect (e.g., increase reputation)
        PlayerReputation.instance.ChangeReputation(reputationChange);

        // Hide the panel after the decision is made
        decisionUIPanel.SetActive(false);

        Debug.Log(decisionMessage);
    }

    // Call this method if the player cancels the decision
    public void CancelDecision()
    {
        // Just hide the panel if the player decides not to proceed
        decisionUIPanel.SetActive(false);
    }
}
