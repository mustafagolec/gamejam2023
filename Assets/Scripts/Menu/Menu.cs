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
    public GameObject coinObj25;
    public GameObject coinObj50;
    public GameObject coinObj100;
    Animator m_Animator;

    public GameObject M_CamObject;
    Cinemachine.CinemachineVirtualCamera c_VirtualCamera;
    public GameObject M_Canvas;
    public GameObject M_BG;

    public GameObject G_Player;
    public GameObject G_UI;
    public GameObject G_TileManager;
    public GameObject G_ObjectManager;

    public GameObject mainmenuObj;
    public GameObject shoppingmenuObj;
    public TimelineAsset timelineAsset;
    public CinemachineDollyCart speed;
    public TMP_Text coinText;
    public AudioSource audioPlayer;
    public AudioClip[] menuSounds;

    private void Start()
    {
        m_Animator = gumMachine.GetComponent<Animator>();
        c_VirtualCamera = M_CamObject.GetComponent<Cinemachine.CinemachineVirtualCamera>();
        coinText.text = $"Coin : {PlayerPrefs.GetInt(coinKey)}";
    }

    public void buttonOne()
    {
        audioPlayer.clip = menuSounds[0];
        audioPlayer.Play();
        m_Animator.SetBool("isStarted", true);
        M_Canvas.SetActive(false);
        coinObj25.SetActive(true);
        Invoke("PlayTimeline", 2f);
        Invoke("SpawnFunc",2.7f);
        PlayerPrefs.SetInt(difficultyKey, 1);
        speed.m_Speed = 1f;
    }

    public void buttonTwo()
    {
        audioPlayer.clip = menuSounds[0];
        audioPlayer.Play();
        m_Animator.SetBool("isStarted", true);
        M_Canvas.SetActive(false);
        coinObj50.SetActive(true);
        Invoke("PlayTimeline", 2f);
        Invoke("SpawnFunc",2.7f);
        PlayerPrefs.SetInt(difficultyKey, 2);
        speed.m_Speed = 1f;
    }

    public void buttonThree()
    {
        audioPlayer.clip = menuSounds[0];
        audioPlayer.Play();
        m_Animator.SetBool("isStarted", true);
        M_Canvas.SetActive(false);
        coinObj100.SetActive(true);
        Invoke("PlayTimeline", 2f);
        Invoke("SpawnFunc",2.7f);
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
        c_VirtualCamera.m_LookAt = G_Player.transform;
        c_VirtualCamera.m_Follow = G_Player.transform;
        Destroy(M_Canvas);
        Destroy(M_BG);
        Destroy(M_CamObject,5f);
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
