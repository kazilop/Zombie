using UnityEngine;


[CreateAssetMenu(fileName = "PotionObject", menuName = "Inventory / Potion")]

public class PotionObject : ItemObject
{

    public int restoreHealth;
    public void Awake()
    {
        type = ItemType.Potion;
    }
}
