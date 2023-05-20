using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private Player playerSc;
    public TMP_Text scoreText;
    public TMP_Text coinText;
    public int coin = 0;
    public float score;

    private void Start()
    {
        playerSc = GetComponent<Player>();
        scoreText = GameObject.FindGameObjectWithTag("Canvas_InGame").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        coinText = GameObject.FindGameObjectWithTag("Canvas_InGame").transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (playerSc.health > 0)
        {
            score += Time.deltaTime*21;
            scoreText.text = $"Score:{score.ToString("0")}";
        }
        coinText.text = $"Coin : {coin}";
        
    }
}
