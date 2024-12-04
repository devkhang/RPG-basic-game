using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory :MonoBehaviour
{
    public static Inventory Instance;
    // Start is called before the first frame update
    public List<InventoryItem> InventoryItems;
    public Dictionary<ItemData, InventoryItem> InventoryDictionary;

    public List<InventoryItem> Stash;
    public Dictionary<ItemData, InventoryItem> StashDictionary;
    [Header("Inventory UI")]
    [SerializeField] private Transform InventorySlotParent;
    [SerializeField] private Transform StashSlotParent;
    private UI_itemSlot[] InventoryItemSlots;
    private UI_itemSlot[] StashItemSlots;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    void Start()
    {
        InventoryItems = new List<InventoryItem>();
        InventoryDictionary = new Dictionary<ItemData, InventoryItem>();

        Stash = new List<InventoryItem>();
        StashDictionary = new Dictionary<ItemData, InventoryItem>();

        InventoryItemSlots = InventorySlotParent.GetComponentsInChildren<UI_itemSlot>();
        StashItemSlots = StashSlotParent.GetComponentsInChildren<UI_itemSlot>();
    }
    private void UpdateSlotUI()
    {
        for(int i = 0; i < InventoryItems.Count; i++)
        {
            InventoryItemSlots[i].updateSlot(InventoryItems[i]);
        }
        for(int i = 0;i < Stash.Count; i++)
        {
            StashItemSlots[i].updateSlot(Stash[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            ItemData item_data = InventoryItems[InventoryItems.Count - 1].ItemData;
            RemoveItem(item_data);
        }
    }
    public void AddItem(ItemData new_Item)
    {
        if(new_Item.ItemType == ItemType.Equipment)
            AddToInventory(new_Item);
        else if(new_Item.ItemType == ItemType.Material)
        {
            AddToStash(new_Item);
        }
        UpdateSlotUI();
    }

    private void AddToStash(ItemData new_Item)
    {
        if (StashDictionary.TryGetValue(new_Item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(new_Item);
            Stash.Add(newItem);
            StashDictionary.Add(new_Item, newItem);
        }
    }

    private void AddToInventory(ItemData new_Item)
    {
        if (InventoryDictionary.TryGetValue(new_Item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(new_Item);
            InventoryItems.Add(newItem);
            InventoryDictionary.Add(new_Item, newItem);
        }
    }

    public void RemoveItem(ItemData new_Item)
    {
        if (InventoryDictionary.TryGetValue(new_Item, out InventoryItem value))
        {
            if(value.stacksize <= 0)
            {
                InventoryDictionary.Remove(new_Item);
                InventoryItems.Remove(value);
            }
            else
            {
                value.stacksize--;
            }
        }
        if (StashDictionary.TryGetValue(new_Item, out InventoryItem StashValue))
        {
            if (StashValue.stacksize <= 0)
            {
                StashDictionary.Remove(new_Item);
                Stash.Remove(StashValue);
            }
            else
            {
                StashValue.stacksize--;
            }
        }
        UpdateSlotUI();
    }
}
