using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ItemType item;
    public float speed;
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
    }
    
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
