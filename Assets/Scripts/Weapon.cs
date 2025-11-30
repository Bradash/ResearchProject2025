using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    public ObjectPool<GameObject> projectilePool;
    public ItemType currentItem;
    public GameObject projectile;
    SpriteRenderer weaponSprite;
    public Transform playerTransform;
    public GameObject trail;

    private void Awake()
    {
        //Make a pool with all these parameters in, Create, Get, Release, Destroy, ReleaseException, default, max
        projectilePool = new ObjectPool<GameObject>(CreatePooledObject, OnGetFromPool, OnReturnToPool, OnDestroyPooledObject, false, 5, 10);
    }
    GameObject CreatePooledObject()
    {
        GameObject projectileNew = Instantiate(projectile, transform.position, playerTransform.rotation);
        var projectileScript = projectileNew.GetComponent<Projectile>();
        projectileScript.weapon = this;
        if (currentItem != null)
        {
            projectileScript.item = currentItem;
        }
        return projectileNew;
    }
    //Get Object
    void OnGetFromPool(GameObject pooledObject)
    {
        pooledObject.SetActive(true);
    }
    //Release Object
    void OnReturnToPool(GameObject pooledObject)
    {
        pooledObject.SetActive(false);
    }
    //Destroy Object (If beyond max)
    void OnDestroyPooledObject(GameObject pooledObject)
    {
        Destroy(pooledObject);
    }
    private void Start()
    {
        weaponSprite = GetComponent<SpriteRenderer>();
    }
    //Set to currentItem.image if not null
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
            //if Bow, instantiate projectile when mouse click
            if (currentItem.isShootable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var shotProjectile = projectilePool.Get();
                    //I was missing this, set position and rotation when re-enabling
                    shotProjectile.transform.position = transform.position;
                    shotProjectile.transform.rotation = playerTransform.rotation;
                }
            }
            //if Sword, Make Object red and enable trail when Mouse click
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
