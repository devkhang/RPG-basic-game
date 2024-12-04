using UnityEngine;

public enum EquipmentType
{
    Armor,
    Weapon,
    Amulet,
    Flask
}

[CreateAssetMenu(fileName = "new Item data", menuName = "data/Equipment")]
public class ItemData_Equipment : ItemData
{  
    public EquipmentType EquipmentType;
}
