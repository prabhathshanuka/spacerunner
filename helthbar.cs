using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helthbar : MonoBehaviour
{
    public Image currentHealthbar;
    private float CurrentAmmo;
    private float MaxAmmo;
    public Text Fireballamount;
    public Text Fireballmaxamount;

    // Start is called before the first frame update
    void Start()
    {

        CurrentAmmo = PlayerPrefs.GetInt("ammo"); 
        MaxAmmo = PlayerPrefs.GetInt("maxammo");
        Fireballamount.text = ((int)CurrentAmmo).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MaxAmmo = PlayerPrefs.GetInt("maxammo");
        Fireballamount.text = ((int)CurrentAmmo).ToString();
        Fireballmaxamount.text = ((int)MaxAmmo).ToString();

        CurrentAmmo = PlayerPrefs.GetInt("ammo");
        UpdateHealthbar();
    }
    private void UpdateHealthbar()
    {
        float ratio = CurrentAmmo / MaxAmmo;
        currentHealthbar.rectTransform.localScale = new Vector3(1, ratio, 1);
    }
}