using UnityEngine;
using UnityEngine.UI;

public class UI_interacteImages : MonoBehaviour
{
    public InventoryManager inventoryManager;

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
    }
}