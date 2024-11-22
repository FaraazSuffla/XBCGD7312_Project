using UnityEngine;
using UnityEngine.UI;

public class EventUIManager : MonoBehaviour
{
    public static EventUIManager instance;

    [SerializeField] private GameObject eventPanel; // UI panel that shows the event
    [SerializeField] private Text eventTitleText; // UI text for the event name
    [SerializeField] private Text eventDescriptionText; // UI text for the event description
    [SerializeField] private Button handleEventButton; // Button to handle the event
    [SerializeField] private Button ignoreEventButton; // Button to ignore the event

    private GameEvent currentEvent;

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

        eventPanel.SetActive(false); // Hide the event panel by default
    }

    // Show the event panel with the event details
    public void ShowEventPanel(GameEvent gameEvent)
    {
        currentEvent = gameEvent;

        // Update the UI text with event details
        eventTitleText.text = gameEvent.eventName;
        eventDescriptionText.text = gameEvent.eventDescription;

        // Show the panel
        eventPanel.SetActive(true);

        // Set button listeners
        handleEventButton.onClick.RemoveAllListeners();
        handleEventButton.onClick.AddListener(() => currentEvent.HandleEvent());

        ignoreEventButton.onClick.RemoveAllListeners();
        ignoreEventButton.onClick.AddListener(() => currentEvent.IgnoreEvent());
    }

    // Hide the event panel
    public void HideEventPanel()
    {
        eventPanel.SetActive(false);
    }
}
