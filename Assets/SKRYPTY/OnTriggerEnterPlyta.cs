using UnityEngine;

public class OnTriggerEnterPlyta : MonoBehaviour
{
    [SerializeField] public GameObject PlytaMinigameCanvas;
    [SerializeField] PlayerMovement playerMovementScript;
    private bool playerInTrigger = false;


    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.L))
        {
            PlytaMinigameCanvas.SetActive(true);
            Debug.Log("set plyta canvas to true");
            playerMovementScript.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            Debug.Log("Player może zagrać w plyte");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            Debug.Log("Player nie moze zagrać w plyte");
        }
    }
}
