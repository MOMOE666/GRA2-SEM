using UnityEngine;

public class Book_interacte : MonoBehaviour, IInteractable
{
    public InventoryManager inventoryManager;
    public QuestManager questManager;
    public int requiredAmount = 5;

    [SerializeField] public AudioSource source;
    [SerializeField] public AudioClip clip;

    public void Interact()
    {
        source.PlayOneShot(clip);
        string nameForInventory = gameObject.name.Split(' ')[0].ToLower().Trim();

        inventoryManager.AddItem(nameForInventory);

        int currentAmount = inventoryManager.GetItemQuantity(nameForInventory);

        if (currentAmount >= requiredAmount)
        {
            if (questManager != null)
            {
                QuestDisplayComponent display = questManager.GetComponentInChildren<QuestDisplayComponent>();
                if (display != null)
                {
                    display.ProgressNode();
                }
            }
        }

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        Destroy(gameObject, clip.length); //działa hoorayyyy
    }
}