using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemType Item;
    Image image;
    public GameObject selectedHighlight;

    public void changeItem()
    {
        image = GetComponent<Image>();
        if (Item != null)
        {
            image.sprite = Item.image;
        }
        else
        {
            image.sprite = null;
        }
    }
}
