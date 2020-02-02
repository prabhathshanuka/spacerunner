using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private float speedx;
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 32.5f;
    private float safeZone =45.0f; 
    private int amnTilesOnScreen = 5;
    private int lastPrfabIndex = 0;
    public GameObject Player;
    //Creat List of Game Object
    private List<GameObject> activeTiles;

   
    // Start is called before the first frame update
   private void Start()
    {
        //asign value to list
        activeTiles = new List<GameObject>();
       //Get player Transform Value
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
       //Display tiles
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 100)
                SpawnTile(0);
            else
                SpawnTile();
           
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Take player Speed value
        speedx = Player.GetComponent<Playerv1>().normalspeed;
        
        
        
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            
            SpawnTile();
            DeleteTile();
        }  
    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomePrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomePrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrfabIndex;
        while (randomIndex == lastPrfabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        if (speedx <35)
        {
            randomIndex = 0;
            return randomIndex;
        }
        else if (speedx < 45)
        {
            randomIndex = 1;
            return randomIndex;
        }
        else if (speedx < 55)
        {
            randomIndex = 2;
            return randomIndex;
        }
        else if (speedx < 65)
        {
            randomIndex = 3;
            return randomIndex;
        }
        else if (speedx < 100)
        {
            randomIndex = 4;
            return randomIndex;
        }
        else
            randomIndex = 4;
        return randomIndex;

        lastPrfabIndex = randomIndex;
        return randomIndex;
    }
     
}
