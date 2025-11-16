using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemType Item;
    public Image image;



    private void Start()
    {
        image.sprite = Item.image;
    }
}
