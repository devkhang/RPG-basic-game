using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_itemSlot : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    [SerializeField]private Image itemImage;
    [SerializeField]private TextMeshProUGUI TextMeshPro;

    [SerializeField]private InventoryItem Item;

    public void updateSlot(InventoryItem _item)
    {
        Item = _item;
        if (Item != null)
        {
            itemImage.color = Color.white;
            itemImage.sprite = Item.ItemData.Icon;
            if (Item.stacksize > 1)
            {
                TextMeshPro.text = Item.stacksize.ToString();
            }
            else
            {
                TextMeshPro.text = "";
            }
        }
    }
    public void ClearUpSlot()
    {
        Item = null;
        itemImage.color = Color.clear;
        itemImage.sprite = null;
        TextMeshPro.text = "";
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Item == null || Item.ItemData == null)
        {
            Debug.LogWarning("Item ho?c ItemData là null!");
            return;
        }
        if (Item.ItemData.ItemType == ItemType.Equipment)
        {
            Inventory.Instance.EquipItem(Item.ItemData);
        }
    }
}
