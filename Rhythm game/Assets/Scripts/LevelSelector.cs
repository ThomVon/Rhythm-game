using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
   public void Select() {
       SceneManager.LoadScene("Main");
   }
   public void SelectlevelTwo() {
       SceneManager.LoadScene("level 2");
   }
}
