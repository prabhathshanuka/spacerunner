using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private Animator anims;

    private void Start()
    {
        anims = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anims.SetTrigger("Collected");
            Debug.Log("GFRTDDDRDTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
            Destroy(gameObject);
        }
    }
}
