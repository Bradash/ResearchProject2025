using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public inventoryClass inventory;
    public InventoryItem[] inventoryItems;
    public ItemType[] itemTypes;
    int[] items;
    [SerializeField]
    public class inventoryClass
    {
        public int[] savedItems;
    }
    //Search for the nearest "Null" ItemType slot inside the Array of InventoryItem Scripts.
    public void Additem(ItemType itemType)
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            InventoryItem Item = inventoryItems[i];
            if (Item.Item == null)
            {
                SpawnItem(itemType, Item);
                return;
            }
        }
    }
    //Set the chosen InventoryItem's ItemType to chosen Itemtype.
    //Then update Sprite
    public void SpawnItem(ItemType itemType, InventoryItem Item)
    {
        Item.Item = itemType;
        Item.changeItem();
    }

    public void Save()
    {
        convertToNumbers();
        //grab public Class
        inventoryClass data = new inventoryClass();
        //set public class values from client side values
        data.savedItems = items;
        //make public class to json
        string json = JsonUtility.ToJson(data);
        //set path with writer
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "item.json"))
        {
            //Serialize and Write file
            writer.Write(json);
        }
    }
    public void LoadGame()
    {
        //string for json
        string json;
        //set path with reader
        using (StreamReader reader = new StreamReader(Application.persistentDataPath + "item.json"))
        {
            //Deserialize to string
            json = reader.ReadToEnd();
        }
        //convert string json to public class
        inventoryClass data = JsonUtility.FromJson<inventoryClass>(json);
        //set client values public class values
        items = data.savedItems;

        convertToItemTypes();

        for (int i = 0; i < inventoryItems.Length; i++)
        {
            inventoryItems[i].changeItem();
        }
    }

    public void convertToNumbers()
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            items[i] = inventoryItems[i].Item.itemID;
        }
    }
    public void convertToItemTypes()
    {
        for (int i = 0; i < itemTypes.Length; i++)
        {
            inventoryItems[i].Item = itemTypes[items[i]];
        }
    }
}
