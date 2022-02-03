using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Exit() {
        Application.Quit();      // Quits the game
        Debug.Log("Game closed");   // This is only temporarely. It's only for testing
    }
    // Game starting code is in the levelselector
}
