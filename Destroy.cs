using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
  
    private int isfly;
    // Start is called before the first frame update
    void Start()
    {
        isfly = PlayerPrefs.GetInt("Flyis");

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (isfly == 1)
        {
            SoundManager.PlaySounds("Explode");
            Debug.Log("Destroiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");



        }

    }
}
   
