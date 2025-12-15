// wont work, needs to be fixed

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    [SerializeField]
    GameObject pauseMenu;

    public static bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                PauseGame();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                ResumeGame();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }


    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    } 
}
