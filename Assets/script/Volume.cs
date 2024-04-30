using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volumemusic;
    public AudioSource music;

    public void VolumeMusic()
    {
        music.volume = volumemusic.value / 2;
    }
}
