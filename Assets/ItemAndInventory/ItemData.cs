using UnityEngine;
public enum ItemType
{
    Material,
    Equipment
}

[CreateAssetMenu(fileName ="new Item data",menuName ="data/Item")]
public class ItemData : ScriptableObject
{
    public ItemType ItemType;
    public string ItemName;
    public Sprite Icon;
}
