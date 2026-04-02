using UnityEngine;
using System.Collections.Generic;
using System;

public class ShopController : MonoBehaviour
{
    public int playerGold = 500;
    
    public List<ItemData> inventory = new();

    public event Action<int> OnGoldChanged;
    public event Action<ItemData> OnItemPurchased;
    public event Action OnInventoryChanged;  

    public bool BuyItem(ItemData item)
    {   
        if (playerGold >= item.price)
        {
            playerGold -= item.price;
            inventory.Add(item);
            
            OnGoldChanged?.Invoke(playerGold);
            OnItemPurchased?.Invoke(item);
            OnInventoryChanged?.Invoke();
            
            Debug.Log($"Purchased: {item.itemName} for {item.price} gold");
            return true;
        }
        else
        {
            Debug.Log("Not enough gold");
            return false;
        }
    }

    public bool CanAfford(ItemData item)
    {
        return playerGold >= item.price;
    }
}