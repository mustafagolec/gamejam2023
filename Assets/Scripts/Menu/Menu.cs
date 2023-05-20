using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
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

    private void Start()
    {
        m_Animator = gumMachine.GetComponent<Animator>();
    }

    public void buttonOne()
    {
        m_Animator.SetBool("isStarted", true);
        Invoke("SpawnFunc",2f);
    }

    public void buttonTwo()
    {
        m_Animator.SetBool("isStarted", true);
        Invoke("SpawnFunc",2f);
    }

    public void buttonThree()
    {
        m_Animator.SetBool("isStarted", true);
        Invoke("SpawnFunc",2f);
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
        //Destroy(M_CamObject);
        Destroy(M_Canvas);
    }
}
