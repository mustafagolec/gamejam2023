using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed = 25f;
    [SerializeField] private float turnSpeed = 200f;
    private int steerValue;


    /*public int target = 60;     */              //FPS AYARLARI BUILDDEN ONCE AC

    private void Start()
    {
        /*Application.targetFrameRate = 60;     //FPS AYARLARI BUILDDEN ONCE AC
        QualitySettings.vSyncCount = 0; */
    }

    void Update()
    {
        /*if(target != Application.targetFrameRate){        //FPS AYARLARI BUILDDEN ONCE AC
            Application.targetFrameRate = target;
        } */

        transform.Translate(Vector3.forward * speed * Time.deltaTime); //ilerleme kodu

        transform.Translate((steerValue / 20f) * turnSpeed * Time.deltaTime, 0f, 0f); //saga sola otele


    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
