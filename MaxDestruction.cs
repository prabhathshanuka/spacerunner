using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxDestruction : MonoBehaviour
{
    private int MaxDestruct;
    public Text Maxdestruction;

    // Start is called before the first frame update
    void Start()
    {
        MaxDestruct = PlayerPrefs.GetInt("HighDestruction");
        Maxdestruction.text = "MaxDestruction: " + ((int)MaxDestruct).ToString();
    }

    
}
