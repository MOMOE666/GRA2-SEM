using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTOMENU : MonoBehaviour
{
    public void GoToSceneOne()
    {
        SceneManager.LoadScene("MainMenu");
    }
}