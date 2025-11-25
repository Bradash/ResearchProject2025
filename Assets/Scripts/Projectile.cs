using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
