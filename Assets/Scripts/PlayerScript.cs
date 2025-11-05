using System.IO;
using UnityEngine;
using static SoundManager;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private void Start()
    {
        LoadColor();
    }
    public Rigidbody2D rb;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + (moveDirection * 5 * Time.fixedDeltaTime));
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
