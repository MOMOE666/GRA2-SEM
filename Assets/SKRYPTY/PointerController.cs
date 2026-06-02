using UnityEngine;
 
public class PointerController : MonoBehaviour
{
    [Header("Obiekty")]
    [SerializeField] public GameObject PlytaMinigameTrigger;
    [SerializeField] public GameObject PlytaCanvas;
    [SerializeField] PlayerMovement playerMovementScript;

    [Header("Los Varjables")]
    public bool IsPlytaDone;
    public Transform pointA; // Reference to the starting point
    public Transform pointB; // Reference to the ending point
    public RectTransform safeZone; // Reference to the safe zone RectTransform
    public float moveSpeed = 100f; // Speed of the pointer movement
 
    private float direction = 1f; // 1 for moving towards B, -1 for moving towards A
    private RectTransform pointerTransform;
    private Vector3 targetPosition;
 
    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
    }
 
    void Update()
    {
        // Move the pointer towards the target position
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);
 
        // Change direction if the pointer reaches one of the points
        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
            direction = 1f;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
            direction = -1f;
        }
 
        // Check for input
        if (Input.GetKeyDown(KeyCode.L))
        {
            CheckSuccess();
        }
    }
 
    void CheckSuccess()
    {
        // Check if the pointer is within the safe zone
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
        {
            Debug.Log("player plyta minigame succesfull");
            PlytaMinigameTrigger.SetActive(false);
            Debug.Log("Minigame trigger zone turned off");
            PlytaCanvas.SetActive(false);
            Debug.Log("Minigame canvas turned off");
            IsPlytaDone = true;
            playerMovementScript.enabled = true;

        }
        else
        {
            Debug.Log("gratulacje zjebales plyta minigame");
        }
    }
}
 