using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Weapon weapon;
    public ItemType item;
    public float speed;
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
    }
    
    private void OnBecameInvisible()
    {
        weapon.projectilePool.Release(gameObject);
    }
}
