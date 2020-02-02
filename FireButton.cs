using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleFirebtn()
    {
        gameObject.SetActive(true);
       
    }
    public void ToggleFirebtnOff()
    {
        gameObject.SetActive(false);

    }
}
