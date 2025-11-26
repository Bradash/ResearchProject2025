using System.IO;
using UnityEngine;
using static SoundManager;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    private void Start()
    {
        //convert string json to public class
        PlayerColor data = JsonUtility.FromJson<PlayerColor>(LoadFile("playerColor.json"));
        //set client values public class values
        spriteRenderer.color = data.savedColor;
    }
    void FixedUpdate()
    {
        playerFaceMouse();
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + (moveDirection * 5 * Time.fixedDeltaTime));
    }
    void playerFaceMouse()
    {
        //make a vector that grabs the mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //make a vector that's based on where the mouse is from the player
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = dir;
    }

    public string LoadFile(string jsonName)
    {
        //string for json
        string json;
        //set path with reader
        using (StreamReader reader = new StreamReader(Application.persistentDataPath + jsonName))
        {
            //Deserialize to string
            json = reader.ReadToEnd();
        }
        return json;
    }
    public class PlayerColor
    {
        public Color savedColor;
    }
}
