using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ItemType currentItem;
    public GameObject projectile;
    SpriteRenderer weaponSprite;
    public Transform playerTransform;
    public GameObject trail;

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
                    GameObject projectileNew = Instantiate(projectile, transform.position, playerTransform.rotation);
                    var projectileScript = projectileNew.GetComponent<Projectile>();
                    if (currentItem != null)
                    {
                        projectileScript.item = currentItem;
                    }
                    else 
                    {
                        Debug.LogError("Projectile is shot from no ItemType");
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    weaponSprite.color = Color.red;
                    trail.SetActive(true);
                }
                
            }
            if (Input.GetMouseButtonUp(0))
            {
                weaponSprite.color = Color.white;
                trail.SetActive(false);
            }
        }
    }
}
