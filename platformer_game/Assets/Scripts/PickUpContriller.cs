using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpContriller : MonoBehaviour
{
    public  int coinValue=1;
    private int keyValue=1;

    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Coin")){
            ScoreManager.instanse.CoinChangeScore(coinValue);
        }
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Key")){
            ScoreManager.instanse.KeyChangeScore(keyValue);
        }
    }

}
