using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    private GameObject playerGO;
    private Player playerSc;

    private void Start() {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerSc = playerGO.GetComponent<Player>();
    }

    public void GoLeft(){
        playerSc.steerValue = -1; 
    }

    public void GoDef(){
        playerSc.steerValue = 0; 
    }
}
