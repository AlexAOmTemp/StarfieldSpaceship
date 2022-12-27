using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string SceneToLoad;
    public void startingNewGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
