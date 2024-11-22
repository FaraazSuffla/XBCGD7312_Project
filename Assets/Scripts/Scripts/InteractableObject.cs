using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    void OnMouseDown()
    {
        Interact();
    }

    public void Interact()
    {
        // Check if the object implements IInteractable
        IInteractable interactable = GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact(); // Call the Interact method defined in IInteractable
            //Debug.Log("Interaction successful!");
        }
        else
        {
            //Debug.Log("You have not interacted with an object.");
        }
    }
}
