using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorChangeScene : MonoBehaviour
{
    public string sceneName = "D102"; // nazwa sceny do wczytania

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneName);
    }
}