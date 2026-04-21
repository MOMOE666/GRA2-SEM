using UnityEngine;

public class Book_interacte : MonoBehaviour, IInteractable
{
    public InventoryManager inventoryManager;
    public QuestManager questManager;
    public int requiredAmount = 2;

    public void Interact()
    {
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

        Destroy(gameObject);
    }
}