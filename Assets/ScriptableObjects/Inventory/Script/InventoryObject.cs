using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName ="New Inventory", menuName = "Inventory / Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;

    public ItemDatabaseObject database;
    public Inventory Container;


    private void OnEnable()
    {

#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject ));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }


    public void AddItem(Item _item, int _amount)
    {
        for(int i = 0; i < Container.Items.Count; i++)
        {
            if (Container.Items[i].item.id == _item.id)
            {
                Container.Items[i].AddAmount(_amount);
                return;
            }
        }

        Container.Items.Add(new InventorySlot(_item.id, _item, _amount));
    }


    public void RemoveItem(Item _item, int _amount)
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (Container.Items[i].item.id == _item.id)
            {
                if(Container.Items[i].amount > 1)
                {
                    Container.Items[i].RemoveAmount(_amount);
                }

                else
                {
                    Container.Items[i].RemoveAmount(_amount);
                    Container.Items.RemoveAt(i);
                }

                //Container.Items[i].AddAmount(_amount);
                return;
            }
        }
    }


    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write); 
        
        formatter.Serialize(stream, Container);
        stream.Close();
    }


    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Container = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
    }


    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
    }

}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();
}


