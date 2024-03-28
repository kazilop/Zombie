using UnityEngine;


[CreateAssetMenu(fileName = "ArmorObject", menuName = "Inventory / Armor")]

public class ArmorObject : ItemObject
{
    public int defenseValue;
    public void Awake()
    {
        type = ItemType.Armor;
    }
}
