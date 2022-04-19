using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // level 1
   public void Select() {
       SceneManager.LoadScene("Main");
   }
   // level 2
   public void SelectlevelTwo() {
       SceneManager.LoadScene("level 2");
   }
   //level 3
   public void SelectlevelThree() {
       SceneManager.LoadScene("rock level");
   }
}
