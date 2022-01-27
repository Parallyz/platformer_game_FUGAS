using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instanse;
   

    public string playerName { get; set; }
    private int lastPlayerLevel;

    private void Start() {
        if(!instanse)
        {
            instanse=this;
        }
    }
    public void ChangePlayerName(string name){
        playerName=name;
    }

    public void LoadRatingList(){
        
    }
}
