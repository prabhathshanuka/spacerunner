using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
     private int hit = 0;
     private int fx = 0;
     private int ammo;
     private GameObject explodeefect;
     public List<GameObject> explodevfx = new List<GameObject>();
     public GameObject firePoint;
     private int maxammo;
     private int Destuction;
     


     // private int     // Start is called before the first frame update
     void Start(){
         explodeefect = explodevfx[0];
         //PlayerPrefs.SetInt("maxammo", 2);
         //PlayerPrefs.SetInt("ammo", 100);
        // if (!(maxammo > 200))
         //{
            // PlayerPrefs.SetInt("ammo", ammo);
//PlayerPrefs.SetInt("maxammo", 200);
        // }

     }


    // Update is called once per frame
    void Update()
    {
       
       
        if (hit > 0)
        {
            SpawnVFX();
            Destroy(gameObject);

           
            
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {

            hit += 1;
            //Debug.Log("HIt my ass");
           
           


        }
       

        else if (other.tag == "Player")
        {
           Debug.Log("KIlled my self");
           
                
        }
    }
    public void SpawnVFX()
    {
        GameObject explodevfx;

        explodevfx = Instantiate(explodeefect, firePoint.transform.position, Quaternion.identity);
        SoundManager.PlaySounds("Explode");
       

       
    }
   
    public void selectFireEfect2()
    {
       float Coinscore = PlayerPrefs.GetFloat("Coinscore");
        //PlayerPrefs.SetInt("maxammo", maxammo);
         int MaxAmmo = PlayerPrefs.GetInt("maxammo");

        ammo = PlayerPrefs.GetInt("ammo");

        if ((Coinscore > 100)&&(ammo<
            maxammo))
        {
            Coinscore = Coinscore - 100;
            PlayerPrefs.SetFloat("Coinscore", Coinscore);

            if (ammo < MaxAmmo)
            {
                ammo += 10;
                PlayerPrefs.SetInt("ammo", ammo);
                Debug.Log("looooooooooops");
            }
            else
            {
                ammo = MaxAmmo;
                PlayerPrefs.SetInt("ammo", ammo);
            }
        }
    }
    
    public void Tagged()
    {
        gameObject.tag = "Enemy"; 
    }
    public void incrsMaxAmmo()
    {
        float Coinscore = PlayerPrefs.GetFloat("Coinscore");
        if (Coinscore > 500)
        {
            
            Coinscore = Coinscore - 500;
            PlayerPrefs.SetFloat("Coinscore", Coinscore);
            int MaxAmmo = PlayerPrefs.GetInt("maxammo");
            MaxAmmo += 10;
            maxammo = MaxAmmo;
            PlayerPrefs.SetInt("maxammo", MaxAmmo);
        }

    }
    
}
