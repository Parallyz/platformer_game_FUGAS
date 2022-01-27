using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
   public void LoadLevelPicker()
   {
       SceneManager.LoadScene(1);
   }

    public void GameQuit()
   {
       print("Quit");
       Application.Quit();
   }

    public void TopList()
   {
      // SceneManager.LoadScene(1);
   }
}
