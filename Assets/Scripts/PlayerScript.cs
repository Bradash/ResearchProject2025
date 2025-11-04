using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Debug.Log(moveDirection);
        rb.AddForce(moveDirection * Time.deltaTime);
    }
}
