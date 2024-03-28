using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount;


    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }


    public void AddAmount(int value)
    {
        amount += value;
    }


    public void RemoveAmount(int value)
    {
        amount -= value;
    }


    public void OnClick()
    {
        Debug.Log("SLOT");
    }



    /*
    public void OnClick()
    {
        // Проверка на наличие предмета
        if (inventory.inventoryItems[slotIndex] != null)
        {
            // Удаление предмета из инвентаря и ячейки
            inventory.RemoveItem(inventory.inventoryItems[slotIndex]);
            itemIcon.sprite = null;
        }
    }
    */
}
