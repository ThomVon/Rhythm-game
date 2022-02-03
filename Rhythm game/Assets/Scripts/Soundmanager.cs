using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour {
    public Slider volumeSlider;    // the slider should be SerializedField but there comes error if it's used
                            // so please don't touch the slider in the editor
    
    void Start() {
        // If there is not saved data, volume will be always 100%
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        // If there is saved data, the game loads it
        else {
            Load();
        }
    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    // To retrive the saved data
    private void Load() {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    // To save the player's data so they don't have change the volume everytime they open the game
    private void Save() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
