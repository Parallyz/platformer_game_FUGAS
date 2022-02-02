using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public  class LevelEndController  : MonoBehaviour
{
    
    public static LevelEndController instanse;
    [SerializeField]
    public  GameObject bgCanvas;

    [SerializeField]

    public  GameObject endLevelCanvas;

    [SerializeField]

    public  GameObject failedLevelCanvas;


    [SerializeField]

    public  TextMeshProUGUI FinalcoinText;

    [SerializeField]

    public  TextMeshProUGUI FinalkeyText;

    

    private void Start() {
        if(!instanse)
        {
            instanse=this;
        }
    }

    // public void NextLevel()
    // {
    //     SceneManager.LoadScene(3);
    // }

    public  void SuccesEndLevel()
    {
        Time.timeScale = 0;
        endLevelCanvas.SetActive(true);
        FinalkeyText.text = "X " + ScoreManager.keyCount.ToString();
        FinalcoinText.text = "X " + ScoreManager.coinCount.ToString();


        bgCanvas.SetActive(false);

        GameController.instanse.SaveGame();
    }

    public void OnNextLevel()
    {
        Time.timeScale = 1;
        GameController.instanse.lastPlayerLevel+=1;
        SceneManager.LoadScene(GameController.instanse.lastPlayerLevel+1);
    }
    public  void FailedEndLevel()
    {
        Time.timeScale = 0;
        failedLevelCanvas.SetActive(true);
        bgCanvas.SetActive(false);

    }
}
