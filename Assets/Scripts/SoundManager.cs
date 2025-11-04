using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Overlays;

public class SoundManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioSource Music;
    public AudioSource[] Sounds;
    public GameObject saveMenu;


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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        //If the files exists open it.
        if(File.Exists(Application.persistentDataPath + "/menudata.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/menudata.dat", FileMode.Open);
        }
        //Else create it.
        else
        {
            file = File.Create(Application.persistentDataPath + "/menudata.dat");
        }
        //Write Data.
        MenuData data = new MenuData();
        data.savedMusicValue = musicSlider.value;
        data.savedSoundValue = soundSlider.value;

        //Write Data.
        bf.Serialize(file, data);
        //Close
        file.Close();
        saveMenu.SetActive(false);

    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/menudata.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            //Open the data
            FileStream file = File.Open(Application.persistentDataPath + "/menudata.dat", FileMode.Open);
            //Deserialize all the data
            MenuData data = (MenuData)bf.Deserialize(file);
            //Set the data
            musicSlider.value = data.savedMusicValue;
            soundSlider.value = data.savedSoundValue;
            file.Close();
        }
    }

    public void dontSave() 
    {
        LoadGame();
        saveMenu.SetActive(false);
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
            Sounds[i].volume *= soundSlider.value;
        }
    }
}
