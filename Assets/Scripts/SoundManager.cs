using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class SoundManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioSource Music;
    public AudioSource[] Sounds;
    public GameObject saveMenu;
    public GameObject menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Start()
    {
        LoadGame();
    }
    public void saveChangesFunc()
    {
        saveMenu.SetActive(true);
    }
    //called by pressing Yes
    public void SaveGame()
    {
        //grab public Class
        MenuData data = new MenuData();
        //set public class values from client side values
        data.savedMusicValue = musicSlider.value;
        data.savedSoundValue = soundSlider.value;
        //make public class to json
        string json = JsonUtility.ToJson(data);
        //set path with writer
        using(StreamWriter writer = new StreamWriter(Application.persistentDataPath + "menudata.json"))
        {
            //Serialize and Write file
            writer.Write(json);
        }

        saveMenu.SetActive(false);
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
            //string for json
            string json;
            //set path with reader
            using(StreamReader reader = new StreamReader(Application.persistentDataPath + "menudata.json"))
            {
            //Deserialize to string
                json = reader.ReadToEnd();
            }
            //convert string json to public class
            MenuData data = JsonUtility.FromJson<MenuData>(json);
            //set client values public class values
            musicSlider.value = data.savedMusicValue;
            soundSlider.value = data.savedSoundValue;
            Debug.Log(data.savedMusicValue);
    }
    //called by pressing no
    public void dontSave() 
    {
        Time.timeScale = 1;
        LoadGame();
        saveMenu.SetActive(false);
        menu.SetActive(false);
    }

    [Serializable]
    public class MenuData
    {
        public float savedMusicValue;
        public float savedSoundValue;
    }

    // Called by touching sliders
    public void UpdateVolumes()
    {
        Music.volume = musicSlider.value;
        for (int i = 0; i < Sounds.Length; i++)
        {
            Sounds[i].volume = soundSlider.value;
        }
    }
}
