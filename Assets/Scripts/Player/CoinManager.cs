using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public const string coinKey = "coinKey"; //1,2,3   //PlayerPrefs.GetInt(difficultyKey) == 1
    public const string moneyKey = "MoneyKey";
    private int totalmoney;
    public int totalCoins;
    public Score scoreSc;
    public Player playerSc;

    void Start()
    {
        scoreSc = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        playerSc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        totalCoins = PlayerPrefs.GetInt(coinKey);
        totalmoney = PlayerPrefs.GetInt(moneyKey);
    }

    private void OnDestroy()
    {
        totalmoney += (int)(scoreSc.score/10);
        PlayerPrefs.SetInt(moneyKey, totalmoney);
        totalCoins += scoreSc.coin;
        PlayerPrefs.SetInt(coinKey, totalCoins);
    }

    private void Update()
    {
        if(playerSc.health == 0){
            Destroy(gameObject);
        }
    }
}
