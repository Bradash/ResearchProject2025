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

    public void SaveGame()
    {
        MenuData data = new MenuData();
        data.savedMusicValue = musicSlider.value;
        data.savedSoundValue = soundSlider.value;

        string json = JsonUtility.ToJson(data);
        using(StreamWriter writer = new StreamWriter(Application.persistentDataPath + "menudata.json"))
        {
            writer.Write(json);
        }

        saveMenu.SetActive(false);
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
            string json;

            using(StreamReader reader = new StreamReader(Application.persistentDataPath + "menudata.json"))
            {
                json = reader.ReadToEnd();
            }

            MenuData data = JsonUtility.FromJson<MenuData>(json);
            musicSlider.value = data.savedMusicValue;
            soundSlider.value = data.savedSoundValue;
            Debug.Log(data.savedMusicValue);
    }

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

    // Update is called once per frame
    public void UpdateVolumes()
    {
        Music.volume = musicSlider.value;
        for (int i = 0; i < Sounds.Length; i++)
        {
            Sounds[i].volume = soundSlider.value;
        }
    }
}
