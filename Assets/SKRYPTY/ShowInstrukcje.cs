using UnityEngine;

public class ShowInstrukcje : MonoBehaviour
{
    [SerializeField] public GameObject pickUpText;
    [SerializeField] public GameObject Instrukcje;
    [SerializeField] PlayerMovement playerMovementScript;
    private bool playerInInstrukcje = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(true);
            playerInInstrukcje = true;
            Debug.Log("Player może podnieść instrukcje");
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(false);
            playerInInstrukcje = false;
        }
    }

    private void Update()
    {
        if (playerInInstrukcje && Input.GetKeyDown(KeyCode.E))
        {
            if (Instrukcje.activeSelf)
            {
            Instrukcje.SetActive(false);
            pickUpText.SetActive(true);
            playerMovementScript.enabled = true;
            Debug.Log("closing instructions");
            }
            else
            {
            playerMovementScript.enabled = false;
            Instrukcje.SetActive(true);
            pickUpText.SetActive(false);
            Debug.Log("showing instructions");
            }
        }
    }

}
