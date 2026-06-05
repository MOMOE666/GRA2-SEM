using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;


    public void PlayGame()
    {
        _sceneController.LoadScene("Main");// this can load the scene number 1 (game)//SceneManager.GetActiveScene().buildIndex +1
        //SceneManager.GetActiveScene().buildIndex + 1
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}