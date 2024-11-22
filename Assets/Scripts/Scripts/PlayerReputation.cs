using UnityEngine;
using UnityEngine.UI;

public class PlayerReputation : MonoBehaviour
{
    public static PlayerReputation instance;

    public int currentReputation = 50; // Starting reputation value
    public Text reputationText; // Reference to the UI Text element displaying reputation

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeReputation(int amount)
    {
        currentReputation += amount;
        Debug.Log("Reputation changed. Current reputation: " + currentReputation);
        UpdateReputationUI();
    }

    void UpdateReputationUI()
    {
        if (reputationText != null)
        {
            reputationText.text = "Reputation: " + currentReputation.ToString();
            Debug.Log("Reputation UI updated: " + reputationText.text);
        }
        else
        {
            Debug.LogWarning("ReputationText reference is missing!");
        }
    }
}
