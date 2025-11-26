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
        projectilePool = new ObjectPool<GameObject>(CreatePooledObject, OnGetFromPool, OnReturnToPool, OnDestroyPooledObject, false, 5, 10);
    }
    GameObject CreatePooledObject()
    {
        GameObject projectileNew = Instantiate(projectile, transform.position, playerTransform.rotation);
        var projectileScript = projectileNew.GetComponent<Projectile>();
        if (currentItem != null)
        {
            projectileScript.item = currentItem;
        }
        return projectileNew;
    }
    void OnGetFromPool(GameObject pooledObject)
    {
        pooledObject.SetActive(true);
    }
    void OnReturnToPool(GameObject pooledObject)
    {
        pooledObject.SetActive(false);
    }
    void OnDestroyPooledObject(GameObject pooledObject)
    {
        Destroy(pooledObject);
    }
    IEnumerator ReturnAfter(GameObject pooledObject)
    {
        yield return new WaitForSeconds(currentItem.Range);
        // Give it back to the pool.
        projectilePool.Release(pooledObject);
    }
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
                    projectilePool.Get();
                    ReturnAfter();
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
