using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomizer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Slider sliderR;
    public Slider sliderG;
    public Slider sliderB;
    Color playerColor;

    private void Start()
    {
        LoadColor();
    }
    private void Update()
    {
        playerColor = new Color(sliderR.value, sliderG.value, sliderB.value);
        spriteRenderer.color = playerColor;
    }
    [SerializeField]
    public class PlayerColor
    {
        public Color savedColor;
    }
    public void SaveColor()
    {
        //grab public Class
        PlayerColor data = new PlayerColor();
        //set public class values from client side values
        data.savedColor = playerColor;
        //make public class to json
        string json = JsonUtility.ToJson(data);
        //set path with writer
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "playerColor.json"))
        {
            //Serialize and Write file
            writer.Write(json);
        }
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
        sliderR.value = data.savedColor.r;
        sliderG.value = data.savedColor.g;
        sliderB.value = data.savedColor.b;
    }
}
