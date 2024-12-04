using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UI_itemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Image Image;
    [SerializeField]private TextMeshProUGUI TextMeshPro;

    [SerializeField]private InventoryItem Item;

    public void updateSlot(InventoryItem _item)
    {
        Item = _item;
        if (Item != null)
        {
            Image.color = Color.white;
            Image.sprite = Item.ItemData.Icon;
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
}
