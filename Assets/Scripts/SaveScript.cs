using System.IO;
using UnityEditor;
using UnityEngine;


public class SaveScript : MonoBehaviour
{
    public class Classname 
    { 
    }

    public void Save(class ClassName, string jsonName)
    {
        //grab public Class
        ClassName data = new publicClass();
        //set public class values from client side values

        //make public class to json
        string json = JsonUtility.ToJson(data);
        //set path with writer
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + jsonName))
        {
            //Serialize and Write file
            writer.Write(json);
        }

        saveMenu.SetActive(false);
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadGame(class ClassName, string jsonName)
    {
        //string for json
        string json;
        //set path with reader
        using (StreamReader reader = new StreamReader(Application.persistentDataPath + jsonName))
        {
            //Deserialize to string
            json = reader.ReadToEnd();
        }
        //convert string json to public class
        ClassName data = JsonUtility.FromJson<ClassName>(json);
        //set client values public class values
    }
}
