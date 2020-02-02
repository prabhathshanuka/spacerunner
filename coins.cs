using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    private float speedx;
    public GameObject[] coinprefab;
    private Transform playerTransform;
    private float spawnZ = 4f;
    private float tileLength = 5f;
    //private float safeZone = 5.0f;
    private int amnCoinsOnScreen = 10;
    private int lastPrfabIndex = 0;
    public GameObject Player;
    //Creat List of Game Object
    private List<GameObject> activeCoins;


    // Start is called before the first frame update
    private void Start()
    {
        //asign value to list
        activeCoins = new List<GameObject>();
        //Get player Transform Value
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //Display tiles
        for (int i = 0; i < amnCoinsOnScreen; i++)
        {
            if (i < 100)
                SpawnCoin(0);
            else
                SpawnCoin();

        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Take player Speed value
        speedx = Player.GetComponent<Playerv1>().normalspeed;



        if (playerTransform.position.z > (spawnZ - amnCoinsOnScreen * tileLength))
        {

            SpawnCoin();
            
        }
    }
    private void SpawnCoin(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(coinprefab[RandomePrefabIndex()]) as GameObject;
        else
            go = Instantiate(coinprefab[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeCoins.Add(go);
        Invoke("DeleteCoin", 5.0f); 
    }
    private void DeleteCoin()
    {
        Destroy(activeCoins[0]);
        activeCoins.RemoveAt(0);
        Debug.Log("CoinDeleted");
    }
    private int RandomePrefabIndex()
    {
        if (coinprefab.Length <= 1)
            return 0;
        int randomIndex = lastPrfabIndex;
        while (randomIndex == lastPrfabIndex)
        {
            randomIndex = Random.Range(0, coinprefab.Length);
        }
        if (speedx < 32)
        {
            randomIndex = Random.Range(0,10); 
            return randomIndex;
        }
        else if (speedx <33)
        {
            randomIndex = Random.Range(0,20);
            return randomIndex;
        }
        else if (speedx < 38)
        {
            randomIndex = Random.Range(0, 40);
            return randomIndex;
        }
        else if (speedx < 43)
        {
            randomIndex = Random.Range(0, 60);
            return randomIndex;
        }
        lastPrfabIndex = randomIndex;
        return randomIndex;
    }
    
}
