using UnityEngine;
using UnityEngine.UI;

public class UI_interacteImages : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public QuestManager questManager;

    [Header("ZDJECIA")]
    public RawImage[] imagesToToggle;

    void Update()
    {
        if (inventoryManager == null || imagesToToggle == null) return;

        int totalQuantity = 0;
        foreach (var item in inventoryManager.inventory)
        {
            totalQuantity += item.quantity;
        }

        for (int i = 0; i < imagesToToggle.Length; i++)
        {
            if (imagesToToggle[i] != null)
            {
                imagesToToggle[i].enabled = (i < totalQuantity);
            }
        }
        
        if (questManager != null)
        {
            questManager.śmieci1.SetActive(totalQuantity >= 1);
            questManager.śmieci2.SetActive(totalQuantity >= 2);
            questManager.śmieci3.SetActive(totalQuantity >= 3);
            questManager.śmieci4.SetActive(totalQuantity >= 4);
            questManager.śmieci5.SetActive(totalQuantity >= 5);
        }
    }
}