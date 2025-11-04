using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource[] Sounds;
    public Slider musicSlider;
    public Slider soundSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Music.volume = musicSlider.value;
        for (int i = 0; i < Sounds.Length; i++)
        {
            Sounds[i].volume = soundSlider.value;
        }  
    }
}
