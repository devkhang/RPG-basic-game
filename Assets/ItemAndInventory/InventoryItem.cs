using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class InventoryItem
{
    public ItemData ItemData;
    public int stacksize;

    public InventoryItem(ItemData itemData)
    { 
        this.ItemData = itemData;
        AddStack();
    }

    public void AddStack() => stacksize++;
    public void RemoveStack() => stacksize--;
}
