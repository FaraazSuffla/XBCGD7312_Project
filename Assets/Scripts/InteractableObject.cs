using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string interactionMessage = "You interacted with the object!";

    void OnMouseDown()
    {
        Interact();
    }

    public void Interact()
    {
        // Check if the object is a ResourceCollectible
        ResourceCollectible resourceCollectible = GetComponent<ResourceCollectible>();
        if (resourceCollectible != null)
        {
            resourceCollectible.Interact();
        }
        else
        {
            Debug.Log(interactionMessage);
            // Add more interaction logic here if needed.
        }
    }
}
