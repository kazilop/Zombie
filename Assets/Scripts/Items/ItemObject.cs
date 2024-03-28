using UnityEngine;


public enum ItemType
{
    Potion,
    Weapon,
    Armor
}


public abstract class ItemObject : ScriptableObject
{
    public int id;
    public Sprite uiDisplay;
    public ItemType type;

    [TextArea(15,15)]
    public string description;


}


[System.Serializable]
public class Item
{
    public string name;
    public int id;

    public Item(ItemObject item)
    {
        this.name = item.name;
        this.id = item.id;
    }

}
