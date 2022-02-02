
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int lastPlayerLevel = 1;



    public int playerCoinsScore;
    public int playerKeyScore;
    public PlayerData()
    {
        playerCoinsScore = ScoreManager.coinCount;
        playerKeyScore = ScoreManager.keyCount;
        playerName = GameController.instanse.playerName;

        lastPlayerLevel = GameController.instanse.lastPlayerLevel;
    }
}
