using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using TMPro;
public class Menu : MonoBehaviour
{
    public const string difficultyKey = "difficulty"; //1,2,3   //PlayerPrefs.GetInt(difficultyKey) == 1, PlayerPrefs.SetInt(difficultyKey, 0);
    public const string coinKey = "coinKey";
    public GameObject gumMachine;
    Animator m_Animator;

    public GameObject M_CamObject;
    public GameObject M_Canvas;

    public GameObject G_Player;
    public GameObject G_UI;
    public GameObject G_TileManager;
    public GameObject G_ObjectManager;

    public GameObject mainmenuObj;
    public GameObject shoppingmenuObj;
    public TimelineAsset timelineAsset;
    public CinemachineDollyCart speed;
    public TMP_Text coinText;

    private void Start()
    {
        m_Animator = gumMachine.GetComponent<Animator>();
        coinText.text = $"Coin : {PlayerPrefs.GetInt(coinKey)}";
    }

    public void buttonOne()
    {
        m_Animator.SetBool("isStarted", true);
        Invoke("PlayTimeline", 2f);
        Invoke("SpawnFunc",2f);
        PlayerPrefs.SetInt(difficultyKey, 1);
        speed.m_Speed = 1f;
    }

    public void buttonTwo()
    {
        m_Animator.SetBool("isStarted", true);
        Invoke("PlayTimeline", 2f);
        Invoke("SpawnFunc",2f);
        PlayerPrefs.SetInt(difficultyKey, 2);
        speed.m_Speed = 1f;
    }

    public void buttonThree()
    {
        m_Animator.SetBool("isStarted", true);
        Invoke("PlayTimeline", 2f);
        Invoke("SpawnFunc",2f);
        PlayerPrefs.SetInt(difficultyKey, 3);
        speed.m_Speed = 1f;
    }

    public void ShoppinMenu() //alışveriş menümüzü aktif eden kodumuz
    {
        mainmenuObj.SetActive(false);
        shoppingmenuObj.SetActive(true);
    }

    public void returnButton()
    {
        mainmenuObj.SetActive(true);
        shoppingmenuObj.SetActive(false);
    }

    void SpawnFunc()
    {
        Instantiate(G_Player, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(G_UI, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(G_TileManager, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(G_ObjectManager, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(M_CamObject);
        Destroy(M_Canvas);
    }

     private void PlayTimeline()
      {
          // Timeline'ı başlat
          if (timelineAsset != null)
          {
              TimelineController timelineController = gameObject.AddComponent<TimelineController>();
              timelineController.Initialize(timelineAsset);
          }
      }
}
