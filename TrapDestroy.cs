using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDestroy : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {

            //speed = 0;
            Destroy(gameObject);
            // Debug.Log("hukanoooooooooooooooooo");
        }

    }
}
