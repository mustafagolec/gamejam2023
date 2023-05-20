using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float destroyTime = 4f;
    private Player playerSc;

    private void Start() {
        playerSc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    private void Update() {
        if(playerSc.health == 5){
            destroyTime = 1f;
        }
        else if(playerSc.health == 4){
            destroyTime = 1.3f;
        }
        else if(playerSc.health == 3){
            destroyTime = 1.8f;
        }
        else if(playerSc.health == 2){
            destroyTime = 2.5f;
        }
        else if(playerSc.health == 1){
            destroyTime = 3f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject,destroyTime);
        }

        if (other.CompareTag("PU_Health"))
        {
            Destroy(other.gameObject,destroyTime);
        }
    }
}
