using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public void Start()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.pausar)
            {
                Resume();
                GameManager.instance.pausar = false;
            }
            else
            {
                Pause();
                GameManager.instance.pausar = true;
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.pausar = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        GameManager.instance.pausar = false;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
