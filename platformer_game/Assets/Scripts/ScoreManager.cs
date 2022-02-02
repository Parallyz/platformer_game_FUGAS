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

    private PlayerData player;

    void Start()
    {
        if (instanse == null)
        {
            instanse = this;
        }
         player = GameController.instanse.GetPlayerByName(GameController.instanse.playerName);

        if (player != null)
        {
            ScoreManager.coinCount = player.playerCoinsScore;
            ScoreManager.keyCount = player.playerKeyScore;
            coinText.text = "X " + coinCount.ToString();
            keyText.text = "X " + keyCount.ToString();
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
        coinCount += coinValue;
        coinText.text = "X " + coinCount.ToString();

    }
    public void KeyChangeScore(int keyValue)
    {
        keyCount += keyValue;
        keyText.text = "X " + keyCount.ToString();


    }
    public void RestartLevel()
    {
        if (player != null)
        {
            ScoreManager.coinCount = player.playerCoinsScore;
            ScoreManager.keyCount = player.playerKeyScore;
            coinText.text = "X " + coinCount.ToString();
            keyText.text = "X " + keyCount.ToString();
        }
    }

    public void FinalPrintScore()
    {
        keyText.text = "X " + keyCount.ToString();
        coinText.text = "X " + coinCount.ToString();
    }


}
