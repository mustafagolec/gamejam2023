using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private Player playerSc;
    public TMP_Text scoreText;
    public float score;

    private void Start()
    {
        playerSc = GetComponent<Player>();
    }

    void Update()
    {
        if (playerSc.health > 0)
        {
            score += Time.deltaTime*21;
            scoreText.text = $"Score:{score.ToString("0")}";
        }
    }
}
