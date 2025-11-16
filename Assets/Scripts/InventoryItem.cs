using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemType Item;
    Image image;

    public void changeItem()
    {
        image = GetComponent<Image>();
        image.sprite = Item.image;
    }
}
