using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ItemType item;
    float range;
    public float speed;
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
        range += Time.deltaTime;
        if (range > item.Range)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
