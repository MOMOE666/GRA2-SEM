using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> itemNames = new List<string>();
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public void AddItem(string itemName)
    {
        string cleanName = itemName.Split(' ')[0].ToLower().Trim();
        InventoryItem existingItem = inventory.Find(item => item.itemName.ToLower() == cleanName);

        if (existingItem != null)
        {
            existingItem.quantity++;
        }
        else
        {
            inventory.Add(new InventoryItem { itemName = cleanName, quantity = 1 });
        }
    }

    public int GetItemQuantity(string itemName)
    {
        string cleanName = itemName.Split(' ')[0].ToLower().Trim();
        InventoryItem item = inventory.Find(i => i.itemName.ToLower() == cleanName);
        return item != null ? item.quantity : 0;
    }

    public bool HasItem(string itemName)
    {
        return GetItemQuantity(itemName) > 0;
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;
}