using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyManager : MonoBehaviour
{
    private float speedx;
    public GameObject[] flyprefab;
    private Transform playerTransform;
    private float spawnZ = 1f;
    private float flylength = 250f;
    //private float safeZone = 5.0f;
    private int amnFlyOnScreen = 1;
    private int lastPrfabIndex = 0;
    public GameObject Player;
    //Creat List of Game Object
    private List<GameObject>activefly;
    bool flyisopen;


    // Start is called before the first frame update
    private void Start()
    {
        //asign value to list
       activefly = new List<GameObject>();
        //Get player Transform Value
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //Display tiles
        // for (int i = 0; i < amnFlyOnScreen; i++)
        // {
        //  if (i < 100)
        //SpawnFly(0);
        // else
        //  SpawnFly();

        //}
    }

    // Update is called once per frame
    private void Update()
    {
        flyisopen = Player.GetComponent<Playerv1>().flyis;
        //Take player Speed value
        speedx = Player.GetComponent<Playerv1>().normalspeed;

        if ((speedx > 30) && (speedx < 100) && !(flyisopen))
        {


            if (playerTransform.position.z > (spawnZ - amnFlyOnScreen * flylength))
            {

                SpawnFly();


            }
        }
    }
    private void SpawnFly(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(flyprefab[RandomePrefabIndex()]) as GameObject;
        else
            go = Instantiate(flyprefab[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += flylength;
       activefly.Add(go);
        Invoke("DeleteFly", 10.0f);
    }
    private void DeleteFly()
    {
        Destroy(activefly[0]);
        activefly.RemoveAt(0);
        Debug.Log("CoinDeleted");
    }
    private int RandomePrefabIndex()
    {
        if (flyprefab.Length <= 1)
            return 0;
        int randomIndex = lastPrfabIndex;
        while (randomIndex == lastPrfabIndex)
        {
            randomIndex = Random.Range(0, flyprefab.Length);
        }
        if (speedx < 90)
        {
            randomIndex = Random.Range(0, 5);
            return randomIndex;
        }
        else if (speedx < 115){
        
        randomIndex = Random.Range(3, 15);
        return randomIndex;
        }
        //else if (speedx < 38)
        //{
        //  randomIndex = Random.Range(0, 1);
        //return randomIndex;
        //}
        // else if (speedx < 43)
        //{
        //  randomIndex = Random.Range(0, 1);
        //return randomIndex;
        //}
        lastPrfabIndex = randomIndex;
        return randomIndex;
    }

}
