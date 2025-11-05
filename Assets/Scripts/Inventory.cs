using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public inventoryClass inventory;
    public ItemType[] itemTypes;
    [SerializeField]
    public class inventoryClass
    {
        public ItemType[] saveditemTypes;
    }

    public void Save()
    {
        //grab public Class
        inventoryClass data = new inventoryClass();
        //set public class values from client side values
        data.saveditemTypes = itemTypes;
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
        itemTypes = data.saveditemTypes;
    }
}
