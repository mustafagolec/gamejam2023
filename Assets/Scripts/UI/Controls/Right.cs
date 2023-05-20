using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right : MonoBehaviour
{
    private GameObject playerGO;
    private Player playerSc;

    private void Start() {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerSc = playerGO.GetComponent<Player>();
    }

    public void GoRight(){
        playerSc.steerValue = 1; 
    }

    public void GoDef(){
        playerSc.steerValue = 0; 
    }
}
