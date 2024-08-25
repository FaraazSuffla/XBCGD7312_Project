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
        Debug.Log(interactionMessage);
        // Here you can add more interaction logic, like opening a door or picking up an item.
    }
}
