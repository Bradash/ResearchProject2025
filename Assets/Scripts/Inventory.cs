using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public inventoryClass inventory;
    public InventoryItem[] inventoryItems;
    public ItemType[] itemTypes;
    public SpriteRenderer weaponSprite;
    public GameObject pickupDrop;
    Pickup pickup;
    public Transform dropLocation;
    int[] items;
    int selectedItem;
    int lastSelected;

    private void Start()
    {
        items = new int[inventoryItems.Length];
        pickup = pickupDrop.GetComponent<Pickup>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = 0;
            changeSelect();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedItem = 1;
            changeSelect();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedItem = 2;
            changeSelect();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            deselect();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            dropItem();
        }
    }

    private void changeSelect()
    {
        inventoryItems[lastSelected].selectedHighlight.SetActive(false);
        lastSelected = selectedItem;
        inventoryItems[selectedItem].selectedHighlight.SetActive(true);
        if (inventoryItems[selectedItem].Item != null) weaponSprite.sprite = inventoryItems[selectedItem].Item.image;
        else weaponSprite.sprite = null;
    }
    private void deselect()
    {
        inventoryItems[selectedItem].selectedHighlight.SetActive(false);
        weaponSprite.sprite = null;
    }

    private void dropItem()
    {
        if (inventoryItems[selectedItem].Item != null) 
        { 
            pickup.item = inventoryItems[selectedItem].Item;
            Instantiate(pickupDrop, dropLocation.position, dropLocation.rotation);
            deselect();
            inventoryItems[selectedItem].Item = null;
            inventoryItems[selectedItem].changeItem();
        }
    }

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
            if (inventoryItems[i].Item != null)
            {
                items[i] = inventoryItems[i].Item.itemID;
            }
            else
            {
                items[i] = 0;
            }    
        }
    }
    public void convertToItemTypes()
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            inventoryItems[i].Item = itemTypes[items[i]];
        }
    }

}
