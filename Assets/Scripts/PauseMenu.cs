using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;  // Reference to the pause menu panel
    public GameObject controlsPanel;  // Reference to the controls panel

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Toggle pause with Escape key
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true); // Show the pause menu
        controlsPanel.SetActive(false); // Ensure controls panel is hidden
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
    }

    public void ShowControls()
    {
        pauseMenuPanel.SetActive(false); // Hide the pause menu
        controlsPanel.SetActive(true);   // Show the controls panel
    }

    public void HideControls()
    {
        controlsPanel.SetActive(false); // Hide the controls panel
        pauseMenuPanel.SetActive(true); // Show the pause menu
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game runs at normal speed
        SceneManager.LoadScene("MainMenu"); // Replace with your main menu scene name
    }
}
