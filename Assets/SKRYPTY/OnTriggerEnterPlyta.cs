using UnityEngine;

public class OnTriggerEnterPlyta : MonoBehaviour
{
    [SerializeField] public GameObject PlytaMinigameCanvas;
    [SerializeField] public GameObject Background;
    [SerializeField] public GameObject Area;
    [SerializeField] public GameObject SafeZone;
    [SerializeField] public GameObject Pointer;
    [SerializeField] public GameObject PointA;
    [SerializeField] public GameObject PointB;

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlytaMinigameCanvas.SetActive(true);
            Background.SetActive(true);
            Area.SetActive(true);
            SafeZone.SetActive(true);
            Pointer.SetActive(true);
            PointA.SetActive(true);
            PointB.SetActive(true);
            Debug.Log("set all plyta minigame parts to active");
        }
    }
}
