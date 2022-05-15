using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;     // This should be SerializedField but there comes error if it's used
                                     // so please don't touch this gameobject in the editor
     
    
    public void Pause() {
        // Pauses the game
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void Resume() {
        // Resumes the game
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.UnPause();
        }
    }

    public void Home(int sceneID) {
        // Takes you to the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
