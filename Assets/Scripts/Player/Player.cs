using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Score scoreSc;
    [SerializeField] public float speed = 10f;
    [SerializeField] private float turnSpeed = 150f;
    [SerializeField] public int health = 3;
    private int maxHealth = 5;
    public Slider healthSlider;
    public int steerValue;
    //public Animator P_Anim;
    

    //sigara kodu
    private bool isSmoking = false;     
    private float smokingDuration = 2f;//Sigara etkisinin ne kadar süreceðini belirle
    private float healthDecreaseInterval = 1f;//Saðlýk azalmasýnýn hangi aralýklarla gerçekleþeceðini belirler
    private float healthDecreaseTimer = 0f;//Saðlýk azalmasýnýn süresini takip eden bir sayaçtýr                                       
    
    public ParticleSystem smokeParticle;
    ParticleSystem temp;


    private void Start()
    {
        healthSlider = GameObject.FindGameObjectWithTag("Canvas_InGame").transform.GetChild(2).GetComponent<Slider>();
        healthSlider.maxValue = health;
        scoreSc = GetComponent<Score>();
       // P_Anim= GetComponent<Animator>();
        
    }

    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //ilerleme kodu
        transform.Translate((steerValue / 20f) * turnSpeed * Time.deltaTime, 0f, 0f); //saga sola otele
        healthUpdate();
        // P_Anim.Play("Walk");

        if (isSmoking)
        {
            healthDecreaseTimer += Time.deltaTime;

            if (healthDecreaseTimer >= healthDecreaseInterval)
            {
                healthDecreaseTimer = 0f;
                health --;
                Debug.Log("saglik:" + health);
            }
        }
    }

    public void Steer(int value)
    {
        steerValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            health--;
            Debug.Log("saglik:" + health);
        }

        if (other.CompareTag("Obstacle_Cigarette"))
        {
            Destroy(other.gameObject);
            health -= 2;
            Debug.Log("saglik:" + health);
            isSmoking = true;
            StartSmoking();
            Invoke(nameof(StopSmoking), smokingDuration);
        }

        if (other.CompareTag("Obstacle_Map"))
        {
            health=0;
        }

        if (other.CompareTag("Coin"))
        {
            scoreSc.coin++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PU_Health"))
        {
            health++;
            if (health >= maxHealth)
            {
                scoreSc.score += 100;
            }
            Debug.Log("saglik:" + health);
        }
    }

    public void HealthSlider(int health)
    {
        healthSlider.value = health;
    }

    private void healthUpdate()
    {
        speed = health * 10;
        turnSpeed = health * 50;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            health = 0;
        }
        HealthSlider(health);
    }


    private void StartSmoking()
    {

        isSmoking = true;
        temp=  Instantiate(smokeParticle);
        temp.transform.position = transform.position;
        temp.transform.parent=transform;
        temp.Play();
        Invoke(nameof(StopSmoking), smokingDuration);
        Debug.Log("Partikül efekti baþladý.");

    }
    private void StopSmoking()
    {
        isSmoking = false;
        temp.Stop();
        Debug.Log("Partikül efekti durduruldu.");
    }
}
