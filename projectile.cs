using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectile : MonoBehaviour
{
    public float rate;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private float timeToFire = 0;
    private GameObject effectToSpawn;
    public bool slowmo = false;
    private int Ammo;
    private int MaxAmmo;
    private float ratio;
    public Slider BulletSlider;
    public GameObject BulletSlide;
    public Text Maxammo;
    public Text CurrentAmmo;
    public GameObject NotEnough;
    // Start is called before the first frame update
    void Start() 
    {
        effectToSpawn = vfx[0];
        rate = effectToSpawn.GetComponent<ProjectileMove>().fireRate;
       

    }

    // Update is called once per frame
 void Update()
   {
       
    }
   public void SpawnVFX()
    {
        Ammo = PlayerPrefs.GetInt("ammo");
        MaxAmmo = PlayerPrefs.GetInt("maxammo");
        GameObject vfx;
        if(firePoint!= null){
            if (Ammo > 0)
            {
                vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
                Ammo -= 1;
                PlayerPrefs.SetInt("ammo", Ammo);
                Debug.Log("Ammo" + Ammo);
                SoundManager.PlaySounds("fire");
                ratio = (float)Ammo / (float)MaxAmmo;
                BulletSlider.value = ratio;
                Debug.Log("Ratiooooo: " + ratio);
                Maxammo.text = MaxAmmo.ToString();
                CurrentAmmo.text = Ammo.ToString();
                NotEnough.SetActive(false);

            }
            else
            {
                ratio = (float)Ammo / (float)MaxAmmo;
                BulletSlider.value = ratio;
                Maxammo.text = MaxAmmo.ToString();
                CurrentAmmo.text = Ammo.ToString();
                NotEnough.SetActive(true);

            }


        }
        else
        {
            Debug.Log("No fire Point");
        }
    }
   public void Click()
   {
       if ( Time.time >= timeToFire)
       {
           BulletSlide.SetActive(true);
           timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
           SpawnVFX();
           slowmo = true;
           Invoke("StopSlowmotion", 0.1f);
       }
           
           
   }
   private void StopSlowmotion()
   {
       slowmo = false;
   }

  
}
