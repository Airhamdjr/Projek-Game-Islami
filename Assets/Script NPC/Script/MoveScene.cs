using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadScene(string sceneName)
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("Login");
        SceneManager.LoadScene("MainScene");
    }

    public void Instruction()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
