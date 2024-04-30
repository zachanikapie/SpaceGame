using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        // Toggle the visibility of the pause menu UI
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

        // Pause or resume the game
        if (pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void ResumeGame()
    {
        // Resume the game and hide the pause menu
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        // Quit the application (only works in standalone builds)
        Application.Quit();
    }
}
