using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidmanager : MonoBehaviour
{
    [SerializeField]astroid asteroid;
    [SerializeField]int gridSpacing = 10;
     [SerializeField]int numberOfAsteroidOnAxis = 100;




    // Start is called before the first frame update
    void Start()
    {
        PlaceAsteroids();
    }
    void PlaceAsteroids()
    {
        for (int x = 0; x < numberOfAsteroidOnAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidOnAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidOnAxis; z++)
                {
                    InstantiateAsteroid(x, y, z);
                }

            }
        }
    }
    void InstantiateAsteroid(int x, int y, int z)
    {
        Instantiate(asteroid,
            new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z),
            Quaternion.identity,
            transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
