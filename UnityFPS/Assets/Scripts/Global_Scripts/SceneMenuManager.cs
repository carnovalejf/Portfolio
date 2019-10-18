using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuManager : MonoBehaviour {


    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject deathScreen;

    public bool gameEnd;

    public bool isPaused;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                Resume();
            }
        }
        if (gameEnd)
        {
            deathScreen.SetActive(true);
        }
	}

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ApplyChanges()
    {
        ReturnToPause();
    }

    public void CancelChanges()
    {
        ReturnToPause();
    }

    public void ReturnToPause()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);   
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    public void Replay2()
    {
        SceneManager.LoadScene("GameScene2", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
