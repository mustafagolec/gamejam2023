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
    private int steerValue;

    private void Start()
    {
        healthSlider.maxValue = health;
        scoreSc = GetComponent<Score>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //ilerleme kodu
        transform.Translate((steerValue / 20f) * turnSpeed * Time.deltaTime, 0f, 0f); //saga sola otele
        healthUpdate();
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

        if (other.CompareTag("PU_Health"))
        {
            health++;
            if (health >= maxHealth)
            {
                scoreSc.score += 100;
            }
            Debug.Log("saglik:" + health);
            Destroy(other.gameObject);
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
        HealthSlider(health);
    }
}
