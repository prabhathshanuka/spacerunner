using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
            
            Destroy(gameObject);
    }
}
