using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject gumMachine;
    Animator m_Animator;

    private void Start() {
        m_Animator = gumMachine.GetComponent<Animator>();
    }
    
    public void buttonOne()
    {
        m_Animator.SetBool("isStarted", true);
    }

    public void buttonTwo()
    {
        m_Animator.SetBool("isStarted", true);
    }

    public void buttonThree()
    {
        m_Animator.SetBool("isStarted", true);
    }
}
