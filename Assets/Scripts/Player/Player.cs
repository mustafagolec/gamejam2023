using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public const string difficultyKey = "difficulty";
    public const string playerSkin = "SkinKey";
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
    private float smokingDuration = 1.5f;//Sigara etkisinin ne kadar s�rece�ini belirle
    private float healthDecreaseInterval = 1f;//Sa�l�k azalmas�n�n hangi aral�klarla ger�ekle�ece�ini belirler
    private float healthDecreaseTimer = 0f;//Sa�l�k azalmas�n�n s�resini takip eden bir saya�t�r                                       
    public AudioSource splat;
    public AudioSource cigaratte;
    public AudioSource water;
    public AudioSource coin;
    public AudioSource walk;
    public AudioSource run;


    public ParticleSystem smokeParticle;
    ParticleSystem temp;
    Animator m_Animator;

    public GameObject defaultGumGo;


    private void Start()
    {
        if (PlayerPrefs.GetInt(difficultyKey) == 1)
        { //BAŞLANGIÇ SEÇENEKLERİ
            health = 3;
        }
        else if (PlayerPrefs.GetInt(difficultyKey) == 2)
        {
            health = 4;
        }
        else if (PlayerPrefs.GetInt(difficultyKey) == 3)
        {
            health = 5;
        }
        healthSlider = GameObject.FindGameObjectWithTag("Canvas_InGame").transform.GetChild(2).GetComponent<Slider>();
        healthSlider.maxValue = health;
        scoreSc = GetComponent<Score>();
        m_Animator = GetComponent<Animator>();
        ColorChecker();

    }

    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //ilerleme kodu
        transform.Translate((steerValue / 20f) * turnSpeed * Time.deltaTime, 0f, 0f); //saga sola otele
        healthUpdate();

        if (isSmoking)
        {
            healthDecreaseTimer += Time.deltaTime;

            if (healthDecreaseTimer >= healthDecreaseInterval)
            {
                healthDecreaseTimer = 0f;
                health--;
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
            cigaratte.Play();
            Destroy(other.gameObject);
            health -= 1;
            Debug.Log("saglik:" + health);
            isSmoking = true;
            StartSmoking();
            Invoke(nameof(StopSmoking), smokingDuration);
        }

        if (other.CompareTag("Obstacle_Map"))
        {
            splat.Play();
            health = 0;
        }

        if (other.CompareTag("Coin"))
        {
            coin.Play();
            scoreSc.coin++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PU_Health"))
        {
            water.Play();
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

        if (health > 1)
        {
            m_Animator.SetBool("isRunning", true);
            m_Animator.SetBool("isWalking", false);
        }
        else if (health == 1)
        {
            m_Animator.SetBool("isWalking", true);
            m_Animator.SetBool("isRunning", false);
        }

        HealthSlider(health);
    }


    private void StartSmoking()
    {
        isSmoking = true;
        temp = Instantiate(smokeParticle);
        temp.transform.position = transform.position;
        temp.transform.parent = transform;
        temp.Play();

        Invoke(nameof(StopSmoking), 1.5f);
        Invoke(nameof(SmokeSoundStop), 3f);
    }
    private void StopSmoking()
    {
        isSmoking = false;
        temp.Stop();
    }

    private void SmokeSoundStop()
    {
        cigaratte.Stop();
    }

    private void ColorChecker()
    {
        if (PlayerPrefs.GetInt(playerSkin) == 2)
        {
            defaultGumGo.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else if (PlayerPrefs.GetInt(playerSkin) == 3)
        {
            defaultGumGo.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (PlayerPrefs.GetInt(playerSkin) == 4)
        {
            defaultGumGo.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (PlayerPrefs.GetInt(playerSkin) == 5)
        {
            defaultGumGo.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (PlayerPrefs.GetInt(playerSkin) == 6)
        {
            defaultGumGo.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
}
