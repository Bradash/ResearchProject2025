using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ItemType currentItem;
    SpriteRenderer weaponSprite;

    private void Start()
    {
        weaponSprite = GetComponent<SpriteRenderer>();
    }
    public void changeItem()
    {
        if (currentItem == null)
        {
            weaponSprite.sprite = null;
        }
        else
        {
            weaponSprite.sprite = currentItem.image;
        }
    }
    void Update()
    {
        
    }
}
