using UnityEngine;

public class FirstPersonRaycaster : MonoBehaviour
{
    public float interactRange = 5f;
    public LayerMask interactableLayer; // Set the layer for interactable objects

    void Update()
    {
        // Raycast from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // Draw the ray for visualization
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red);

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer))
        {
            InteractableObject interactable = hit.transform.GetComponent<InteractableObject>();
            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }
    }
}
