using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    public  void SuccesEndLevel()
    {
        Time.timeScale = 0;
        endLevelCanvas.SetActive(true);
        FinalkeyText.text = "X " + ScoreManager.keyCount.ToString();
        FinalcoinText.text = "X " + ScoreManager.coinCount.ToString();


        bgCanvas.SetActive(false);

    }

    public  void FailedEndLevel()
    {
        Time.timeScale = 0;
        failedLevelCanvas.SetActive(true);
        bgCanvas.SetActive(false);

    }
}
