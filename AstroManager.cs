using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroManager : MonoBehaviour
{
    private float speedx;
    public GameObject[] astroprefab;
    private Transform playerTransform;
    private float spawnZ = 2f;
    private float astrolength = 30f;
    //private float safeZone = 5.0f;
    private int amnAstroOnScreen = 4;
    private int lastPrfabIndex = 0;
    public GameObject Player;
    //Creat List of Game Object
    private List<GameObject> activeAstro;


    // Start is called before the first frame update
    private void Start()
    {
        //asign value to list
        activeAstro = new List<GameObject>();
        //Get player Transform Value
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //Display tiles
       // for (int i = 0; i < amnAstroOnScreen; i++)
       // {
          //  if (i < 100)
//SpawnAstro(0);
           // else
              //  SpawnAstro();

        //}
    }

    // Update is called once per frame
    private void Update()
    {
        //Take player Speed value
        speedx = Player.GetComponent<Playerv1>().normalspeed;

        if (speedx > 80)
        {


            if (playerTransform.position.z > (spawnZ - amnAstroOnScreen * astrolength))
            {

                SpawnAstro();


            }
        }
    }
    private void SpawnAstro(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(astroprefab[RandomePrefabIndex()]) as GameObject;
        else
            go = Instantiate(astroprefab[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += astrolength;
        activeAstro.Add(go);
        Invoke("DeleteCoin", 5.0f);
    }
    private void DeleteCoin()
    {
        Destroy(activeAstro[0]);
        activeAstro.RemoveAt(0);
        Debug.Log("CoinDeleted");
    }
    private int RandomePrefabIndex()
    {
        if (astroprefab.Length <= 1)
            return 0;
        int randomIndex = lastPrfabIndex;
        while (randomIndex == lastPrfabIndex)
        {
            randomIndex = Random.Range(0, astroprefab.Length);
        }
        if (speedx > 38)
        {
            randomIndex = Random.Range(0, 1);
            return randomIndex;
        }
        //else if (speedx < 35)
        //{
          //  randomIndex = Random.Range(0, 1);
            //return randomIndex;
        //}
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
