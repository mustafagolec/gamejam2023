using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    private Transform playerTransform;
    private float spawnZ = -300.0f;
    private float safeZone = 300.0f;
    private float tileLength = 300.0f;
    private int amnTilesOnScreen = 2;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;

    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(groundPrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile(int prefabIndex = -1)
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        int randomIndex = 0;
        if (groundPrefabs.Length <= 1)
        {
            return 0;
        }
        randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, groundPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;

        return randomIndex;
    }
}
