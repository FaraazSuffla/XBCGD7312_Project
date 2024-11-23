using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;

    private Rigidbody rb; // Reference to the Rigidbody
    private Vector3 lastSafePosition; // Track the last position where the player wasn't colliding

    private bool isColliding = false; // Whether the player is colliding with an obstacle

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing from the player object!");
        }

        // Initialize the last safe position
        lastSafePosition = transform.position;
    }

    void Update()
    {
        // Player rotation (horizontal)
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        // Camera rotation (vertical)
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Unlock the cursor when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void FixedUpdate()
    {
        // Movement logic
        float moveForward = Input.GetAxis("Vertical") * speed;
        float moveSide = Input.GetAxis("Horizontal") * speed;

        // Calculate movement vector
        Vector3 move = transform.right * moveSide + transform.forward * moveForward;

        // Only apply movement if not moving deeper into an obstacle
        if (isColliding)
        {
            // Check if the movement direction is away from the last safe position
            Vector3 directionToSafePosition = (lastSafePosition - transform.position).normalized;
            if (Vector3.Dot(move.normalized, directionToSafePosition) > 0)
            {
                rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
            }
        }
        else
        {
            rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
        }

        // Update the last safe position when not colliding
        if (!isColliding)
        {
            lastSafePosition = transform.position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Trigger collision logic only for obstacles
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // End collision logic for obstacles
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isColliding = false;
        }
    }
}
