using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public string playerName { get; set; }
    public int coins;
    public int keys;

    public int health { get; set; }

    public Vector2 respawn { get; set; }
    public PlayerData()
    {
        coins = ScoreManager.coinCount;
        keys = ScoreManager.keyCount;
        playerName = GameController.instanse.playerName;
    }
}
