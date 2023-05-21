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
    public const string playerSkin = "SkinKey"; //1,2,3,4,5,6
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
    private int totalcoin;


    private bool isWhiteUnlocked = false;
    private bool isRedUnlocked = false;
    private bool isBlueUnlocked = false;
    private bool isGreenUnlocked = false;
    private bool isGoldUnlocked = false;
    public GameObject[] colorTexts;
    public const string WhiteSkin = "WhiteSkinKey";
    public const string RedSkin = "RedSkinKey";
    public const string BlueSkin = "BlueSkinKey";
    public const string GreenSkin = "GreenSkinKey";
    public const string GoldSkin = "GoldSkinKey";

    private void Start()
    {
        m_Animator = gumMachine.GetComponent<Animator>();
        c_VirtualCamera = M_CamObject.GetComponent<Cinemachine.CinemachineVirtualCamera>();
        totalcoin = PlayerPrefs.GetInt(coinKey);

    }

    private void Update()
    {
        coinText.text = $"Coin : {totalcoin}";
        PlayerPrefs.SetInt(coinKey, totalcoin);
        if (PlayerPrefs.GetInt(WhiteSkin) == 1)
        {
            isWhiteUnlocked = true;
            colorTexts[0].SetActive(false);
        }

        if (PlayerPrefs.GetInt(RedSkin) == 1)
        {
            isRedUnlocked = true;
            colorTexts[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt(BlueSkin) == 1)
        {
            isBlueUnlocked = true;
            colorTexts[2].SetActive(false);
        }

        if (PlayerPrefs.GetInt(GreenSkin) == 1)
        {
            isGreenUnlocked = true;
            colorTexts[3].SetActive(false);
        }

        if (PlayerPrefs.GetInt(GoldSkin) == 1)
        {
            isGoldUnlocked = true;
            colorTexts[4].SetActive(false);
        }
    }

    public void buttonOne()
    {
        audioPlayer.clip = menuSounds[0];
        audioPlayer.Play();
        m_Animator.SetBool("isStarted", true);
        M_Canvas.SetActive(false);
        coinObj25.SetActive(true);
        Invoke("PlayTimeline", 2f);
        Invoke("SpawnFunc", 2.7f);
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
        Invoke("SpawnFunc", 2.7f);
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
        Invoke("SpawnFunc", 2.7f);
        PlayerPrefs.SetInt(difficultyKey, 3);
        speed.m_Speed = 1f;
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
        Destroy(M_CamObject);
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

    public void ShoppinMenu() //alışveriş menümüzü aktif eden kodumuz
    {
        mainmenuObj.SetActive(false);
        shoppingmenuObj.SetActive(true);
    }

    public void M_Pink()
    {
        PlayerPrefs.SetInt(playerSkin, 1);
    }
    public void M_White()
    {
        if (isWhiteUnlocked)
        {
            PlayerPrefs.SetInt(playerSkin, 2);
        }
        else if (!isWhiteUnlocked && totalcoin > 30)
        {
            isWhiteUnlocked = true;
            totalcoin -= 30;
            PlayerPrefs.SetInt(WhiteSkin, 1);
            colorTexts[0].SetActive(false);
        }
    }
    public void M_Red()
    {
        if (isRedUnlocked)
        {
            PlayerPrefs.SetInt(playerSkin, 3);
        }
        else if (!isRedUnlocked && totalcoin > 40)
        {
            isRedUnlocked = true;
            totalcoin -= 40;
            PlayerPrefs.SetInt(RedSkin, 1);
            colorTexts[1].SetActive(false);
        }
    }
    public void M_Blue()
    {
        if (isBlueUnlocked)
        {
            PlayerPrefs.SetInt(playerSkin, 4);
        }
        else if (!isBlueUnlocked && totalcoin > 50)
        {
            isBlueUnlocked = true;
            totalcoin -= 50;
            PlayerPrefs.SetInt(BlueSkin, 1);
            colorTexts[2].SetActive(false);
        }
    }
    public void M_Green()
    {
        if (isGreenUnlocked)
        {
            PlayerPrefs.SetInt(playerSkin, 5);
        }
        else if (!isGreenUnlocked && totalcoin > 60)
        {
            isGreenUnlocked = true;
            totalcoin -= 60;
            PlayerPrefs.SetInt(GreenSkin, 1);
            colorTexts[3].SetActive(false);
        }
    }
    public void M_Gold()
    {
        if (isGoldUnlocked)
        {
            PlayerPrefs.SetInt(playerSkin, 6);
        }
        else if (!isGoldUnlocked && totalcoin > 100)
        {
            isGoldUnlocked = true;
            totalcoin -= 100;
            PlayerPrefs.SetInt(GoldSkin, 1);
            colorTexts[4].SetActive(false);
        }
    }

}
