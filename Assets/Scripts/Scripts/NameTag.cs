using TMPro;
using UnityEngine;

public class NameTag : MonoBehaviour
{
    public string npcName; // Set this in the Inspector or dynamically
    public TextMeshProUGUI nameText; // Assign in the Inspector
    public Transform cameraTransform;

    void Start()
    {
        if (nameText != null)
            nameText.text = npcName;

        // Reference the main camera
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Ensure the canvas always faces the camera
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward,
                         cameraTransform.rotation * Vector3.up);
    }
}
