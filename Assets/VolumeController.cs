using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null; // volumeslider object
    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
    }
    
    // save the current value on the slider
    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
        LoadValues();
    }

    // load the volume values
    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume", 0.3f); // get the float value or 0.3f on default
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
