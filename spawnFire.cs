using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFire : MonoBehaviour
{
    public float rate;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private float timeToFire = 0;
    private GameObject effectToSpawn;
    public rotateToMouse rotateToMouse;
    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
        rate = effectToSpawn.GetComponent<ProjectileMove>().fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (MobileInput.Instance.Tap)
        {
            SpawnVFX();
        }
    }
    public void SpawnVFX()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            
                vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
                if (rotateToMouse != null)
                {
                    vfx.transform.localRotation = rotateToMouse.GetRotation();
                }
               
        }
        else
        {
            Debug.Log("No fire Point");
        }


        }
        
    }

