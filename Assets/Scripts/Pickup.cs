using UnityEngine;

public class Pickup : MonoBehaviour
{
    ItemType item;
    public Inventory inventory;
    SpriteRenderer spriteRenderer;

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.image;
    }

    private void OnCollisionEnter(Collision collision)
    {
        inventory = collision.gameObject.GetComponent<Inventory>();
        inventory.Additem(item);
        Destroy(gameObject);
    }
}
