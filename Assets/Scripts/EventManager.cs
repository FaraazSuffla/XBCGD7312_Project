using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public float timeBetweenEvents = 60f; // Time between events (in seconds)
    private float eventTimer; // Tracks time until the next event

    public List<GameEvent> possibleEvents = new List<GameEvent>(); // List of possible events

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

    private void Start()
    {
        eventTimer = timeBetweenEvents; // Initialize the timer
    }

    private void Update()
    {
        eventTimer -= Time.deltaTime; // Count down to the next event

        if (eventTimer <= 0)
        {
            TriggerRandomEvent(); // Trigger a new event when the timer hits zero
            eventTimer = timeBetweenEvents; // Reset the timer
        }
    }

    // Trigger a random event from the list of possible events
    private void TriggerRandomEvent()
    {
        if (possibleEvents.Count > 0)
        {
            int randomIndex = Random.Range(0, possibleEvents.Count);
            GameEvent randomEvent = possibleEvents[randomIndex];

            randomEvent.TriggerEvent(); // Trigger the selected event
        }
    }
}
