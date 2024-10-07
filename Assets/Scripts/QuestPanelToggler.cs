using UnityEngine;

public class QuestPanelToggler : MonoBehaviour
{
    public GameObject questPanel; // Reference to the quest UI panel
    private bool isPanelVisible = false; // Track whether the panel is visible or not

    private void Start()
    {
        // Ensure the panel is hidden at the start
        questPanel.SetActive(false);
    }

    private void Update()
    {
        // Listen for a key press (e.g., "Q" key)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleQuestPanel(); // Toggle the quest panel when "Q" is pressed
        }
    }

    // Toggle the visibility of the quest panel
    public void ToggleQuestPanel()
    {
        isPanelVisible = !isPanelVisible; // Toggle the visibility state
        questPanel.SetActive(isPanelVisible); // Show or hide the panel based on the state
    }
}
