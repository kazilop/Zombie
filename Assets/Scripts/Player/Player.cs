using UnityEngine;


public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    private DisplayInventory displayInventory;


    private void Start()
    {
        displayInventory = GetComponent<DisplayInventory>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<GroundItem>();
        if(item != null)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Save();

        //Очистка 
       //inventory.Container.Items.Clear();
    }


    public void Die()
    {
        Debug.Log("DIE !");
    }


    public void InventoryRemoveQnty(Item item, int amount)
    {
        inventory.RemoveItem(item, amount);
    }
}
