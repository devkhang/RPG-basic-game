using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private ItemData ItemData;
    private void OnValidate()
    {
        GetComponent<SpriteRenderer>().sprite = ItemData.Icon;
        gameObject.name = "Item name : "+ItemData.ItemName;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<player>()!=null)
        {
            Inventory.Instance.AddItem(ItemData);
            Destroy(gameObject);
        }
    }
}
