using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Player playerSc;
    public GameObject gameOverMenu;
    public GameObject pauseButton;
    public GameObject inGameMenuButton;
    public GameObject settingsMenuButton;
    
    int current_index;
    
    void Start()
    {
        playerSc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        current_index = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("current scene id: " + current_index);
    }

    void Update()
    {
        if(playerSc.health==0){
            gameOverMenu.SetActive(true);
            pauseButton.SetActive(false);
            inGameMenuButton.SetActive(false);
            settingsMenuButton.SetActive(false);
        }
        else{
            gameOverMenu.SetActive(false);
        }
    }

    public void Restart(){
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        SceneManager.LoadScene(current_index);
    }
}
