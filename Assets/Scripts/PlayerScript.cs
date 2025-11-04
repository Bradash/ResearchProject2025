using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody2D rb;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb.MovePosition(rb.position + (moveDirection * 5 * Time.fixedDeltaTime));
    }
}
