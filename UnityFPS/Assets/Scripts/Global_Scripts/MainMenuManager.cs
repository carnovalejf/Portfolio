using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public GameObject optionsMenu;

    public GameObject mainMenu;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ApplyChanges()
    {
        ReturnToMain();
    }

    public void CancelChanges()
    {
        ReturnToMain();
    }

    public void ReturnToMain()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void StartSingleGame()
    {

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void StartMultiGame()
    {

        SceneManager.LoadScene("GameScene2", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
