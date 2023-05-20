using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] ObjectPrefabs;
    private Transform playerTransform;
    private int lastPrefabIndex = 0;
    private float ObjectX = 0f;
    [SerializeField] private float ObjectZ = 250f;
    [SerializeField] private float StartTime = 0f;
    [SerializeField] private float SpawnTime = 2.0f;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("Obje Olusturma Zamani: "+SpawnTime);
        InvokeRepeating("SpawnObject", StartTime, SpawnTime);  //sagdaki ileride hiza gore degissin
    }

    void Update()
    {
        ObjectX = Random.Range(-100f, 100f);
    }


    void SpawnObject()
    {
        Instantiate(ObjectPrefabs [RandomPrefabIndex()], new Vector3(playerTransform.position.x+ObjectX,playerTransform.position.y,playerTransform.position.z+ObjectZ), playerTransform.rotation);
    }

    private int RandomPrefabIndex(){
        if(ObjectPrefabs.Length <=1){
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex){
            randomIndex = Random.Range (0,ObjectPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
    
