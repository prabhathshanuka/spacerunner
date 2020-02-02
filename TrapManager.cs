using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    private float speedx;
    public GameObject[] TrapPrefab;
    private Transform playerTransform;
    private float spawnZ = 5f;
    private float TrapLength = 30f;
    //private float safeZone = 5.0f;
    private int amnTrapOnScreen = 3;
    private int lastPrfabIndex = 0;
    public GameObject Player;
    //Creat List of Game Object
    private List<GameObject> activeTrap;


    // Start is called before the first frame update
    private void Start()
    {
        //asign value to list
        activeTrap = new List<GameObject>();
        //Get player Transform Value
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //Display tiles
        for (int i = 0; i < amnTrapOnScreen; i++)
        {
            if (i < 1000)
                SpawnTrap(0);
            else
                SpawnTrap();

        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Take player Speed value
        speedx = Player.GetComponent<Playerv1>().normalspeed;
       
            if (playerTransform.position.z > (spawnZ - amnTrapOnScreen * TrapLength))
            {

                SpawnTrap();
                DeleteTrap();
            }
        
    }
    private void SpawnTrap(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(TrapPrefab[RandomePrefabIndex()]) as GameObject;
        else
            go = Instantiate(TrapPrefab[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += TrapLength;
        activeTrap.Add(go);
    }
    private void DeleteTrap()
    {
        Destroy(activeTrap[0]);
        activeTrap.RemoveAt(0);
    }
    private int RandomePrefabIndex()
    {
        if (TrapPrefab.Length <= 1)
            return 0;
        int randomIndex = lastPrfabIndex;
        while (randomIndex == lastPrfabIndex)
        {
            randomIndex = Random.Range(0, TrapPrefab.Length);
        }
        if (speedx < 32)
        {
            randomIndex = Random.Range(0, 12);
            return randomIndex;
        }
        else if (speedx < 40)
        {
            randomIndex = Random.Range(0, 12);
            return randomIndex;
        }
        else if (speedx < 70)
        {
            randomIndex = Random.Range(0, 12);
            return randomIndex;
        }
        else
        {
            randomIndex = Random.Range(0, 12);
            return randomIndex;
        }
        lastPrfabIndex = randomIndex;
        return randomIndex;
    }

}
