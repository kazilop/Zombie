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
        Debug.Log("Collision");
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
       // inventory.Container.Items.Clear();
    }
}
