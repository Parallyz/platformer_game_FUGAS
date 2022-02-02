using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instanse;


    public string playerName { get; set; } = "Player";
    public int lastPlayerLevel { get; set; } = 0;

    public void SaveGame()
    {
        SaveSystem.SaveGame();
    }
    public bool isHaveSaving()
    {
        return SaveSystem.isSaveFileCreated();
    }
    public PlayerData[] LoadGame()
    {
        return SaveSystem.LoadFromFile();

    }

    public void LoadLastPlayer()
    {
        var player = SaveSystem.GetLastPlayer();
        if (player != null)
        {
            playerName = player.playerName;
            lastPlayerLevel = player.lastPlayerLevel;

        }

    }

    public PlayerData GetPlayerByName(string name)
    {
        return SaveSystem.FindPlayerByName(name);
    }
    private void Start()
    {
        if (!instanse)
        {
            instanse = this;
            LoadLastPlayer();

        }
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public PlayerData GetLastPlayer()
    {
        return SaveSystem.GetLastPlayer();
    }
    public void ChangePlayerName(string name)
    {
        playerName = name;
    }

    public void ChangeLastLevel(int level)
    {
        lastPlayerLevel = level;
    }
}
