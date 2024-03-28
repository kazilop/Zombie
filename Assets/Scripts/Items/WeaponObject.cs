using UnityEngine;


[CreateAssetMenu(fileName = "WeaponObject", menuName = "Inventory / Weapon")]
public class WeaponObject : ItemObject
{
    public int power;
    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
