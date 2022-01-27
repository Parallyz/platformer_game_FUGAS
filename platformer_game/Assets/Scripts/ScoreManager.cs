using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
  public static ScoreManager instanse;

  [SerializeField]
  private TextMeshProUGUI coinText;
  [SerializeField]
  private TextMeshProUGUI keyText;


  
 

  

  public static int coinCount { get; set; }           
 
  public static int keyCount { get; set; }

    void Start()
    {
        if(instanse==null)
        {
            instanse=this;
        }
        // PlayerData data= SaveSystem.LoadPlayer();
        // if(data!=null)
        // {
        //     coinCount=data.coins;
        //     keyCount=data.keys;
        // }
    }

    public void CoinChangeScore(int coinValue)
    {
        coinCount+=coinValue;
        coinText.text="X "+coinCount.ToString();
       
    }
     public void KeyChangeScore(int keyValue)
    {
        keyCount+=keyValue;
        keyText.text="X "+keyCount.ToString();
       

    }
    public void RestartLevel()
    {
        keyCount=0;
        coinCount=0;
    }
     public void FinalPrintScore()
    {
        keyText.text="X "+keyCount.ToString();
        coinText.text="X "+coinCount.ToString();
    }
    

}
