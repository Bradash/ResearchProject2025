using System.IO;
using UnityEngine;
using static SoundManager;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    private void Start()
    {
        LoadColor();
    }
    void Update()
    {
        playerFaceMouse();
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + (moveDirection * 5 * Time.deltaTime));
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

    public void LoadColor()
    {
        //string for json
        string json;
        //set path with reader
        using (StreamReader reader = new StreamReader(Application.persistentDataPath + "playerColor.json"))
        {
            //Deserialize to string
            json = reader.ReadToEnd();
        }
        //convert string json to public class
        PlayerColor data = JsonUtility.FromJson<PlayerColor>(json);
        //set client values public class values
        spriteRenderer.color = data.savedColor;
    }
    public class PlayerColor
    {
        public Color savedColor;
    }
}
