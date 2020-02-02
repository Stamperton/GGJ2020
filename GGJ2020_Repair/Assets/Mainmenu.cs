using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas InfoScreenCanvas;

    private void Start()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        InfoScreenCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToInfoScreen()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        InfoScreenCanvas.gameObject.SetActive(true);
    }

    public void GoToMainMenu()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        InfoScreenCanvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
