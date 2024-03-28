using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] Transform itemPanel;

    public GameObject inventoryPrefab;
    public InventoryObject inventory;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
     

    void Update()
    {
        if (inventoryPrefab != null)
        {
           // CreateDisplay();
            UpdateDisplay();
        }

    }


    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];

            if (itemsDisplayed.ContainsKey(slot))
            {
                if (slot.amount > 1)
                {
                    itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                }
            }

            else
            {
                var obj = Instantiate(inventoryPrefab,
                Vector3.zero,
                Quaternion.identity, transform);

                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.id].uiDisplay;
                obj.transform.SetParent(itemPanel, false);
                itemsDisplayed.Add(slot, obj);
            }
        
        }
    }


    private void CreateDisplay()
    {
        for(int i =0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];

            var obj = Instantiate(inventoryPrefab,
                Vector3.zero,
                Quaternion.identity, transform);

            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = 
                inventory.database.GetItem[slot.item.id].uiDisplay;


            if (slot.amount <= 1)
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().text = "";

            }
            else if (slot.amount > 1)
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            }

            obj.transform.SetParent(itemPanel, false);
            itemsDisplayed.Add(slot, obj);
        }
    }

}
