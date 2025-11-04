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
    public void dontSave() 
    {
        saveMenu.SetActive(false);
    }

    [Serializable]
    public class MenuData
    {
        public float savedMusicValue;
        public float savedSoundValue;
    }

    // Update is called once per frame
    void Update()
    {
        Music.volume = musicSlider.value;
        for (int i = 0; i < Sounds.Length; i++)
        {
            Sounds[i].volume *= soundSlider.value;
        }
    }
}
