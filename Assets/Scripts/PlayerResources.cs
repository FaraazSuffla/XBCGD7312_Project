using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResources instance;

    public int currentResources = 0; // Tracks the total resources collected
    public Text resourceText; // Reference to the UI Text element displaying resources

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

    public void AddResource(int amount)
    {
        currentResources += amount;
        Debug.Log("Resource added. Current resources: " + currentResources);
        UpdateResourceUI();
    }

    void UpdateResourceUI()
    {
        if (resourceText != null)
        {
            resourceText.text = "Resources: " + currentResources.ToString();
            Debug.Log("Resource UI updated: " + resourceText.text);
        }
        else
        {
            Debug.LogWarning("ResourceText reference is missing!");
        }
    }
}
