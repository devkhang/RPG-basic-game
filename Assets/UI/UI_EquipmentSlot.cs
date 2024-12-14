using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EquipmentSlot : UI_itemSlot
{
    public EquipmentType SlotType;
    public void OnValidate()
    {
        gameObject.name = "Equipment slot - " + SlotType.ToString();
    }
}
