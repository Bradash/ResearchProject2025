using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ItemType currentItem;
    public GameObject projectile;
    SpriteRenderer weaponSprite;
    public Transform playerTransform;

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
        if (currentItem != null)
        {
            if (currentItem.isShootable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(projectile, transform.position, playerTransform.rotation);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {

                }
            }
        }
    }
}
