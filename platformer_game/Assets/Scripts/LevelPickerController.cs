using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPickerController : MonoBehaviour
{

    public void LoadFirstlvl()
    {
        GameController.instanse.lastPlayerLevel = 1;
        LoadLevel();

    }

     public void LoadSecondlvl()
    {
        GameController.instanse.lastPlayerLevel = 2;
        LoadLevel();

    }
     public void LoadThirdlvl()
    {
        GameController.instanse.lastPlayerLevel = 3;
        LoadLevel();

    }
     public void LoadFourthlvl()
    {
        GameController.instanse.lastPlayerLevel = 4;
        LoadLevel();

    }
     public void LoadFifthlvl()
    {
        GameController.instanse.lastPlayerLevel = 5;
        LoadLevel();

    }
    private void LoadLevel()
    {
        SceneManager.LoadScene(GameController.instanse.lastPlayerLevel + 1);
        
    }
}
