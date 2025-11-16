using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemType Item;
    Image image;



    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = Item.image;
    }
}
