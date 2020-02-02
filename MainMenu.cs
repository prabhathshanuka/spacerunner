using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;
    public Text CoinscoreText;
    public Text LifeText;
    public Text Maxdestruct;
    public Text MaxCapacity;
    public Text CurCapacity;
    public Text DetuctCoin;
    public GameObject Detuct;
    public GameObject NotEnough;
    public GameObject CoinSack;
    public GameObject LifeUP;
    public GameObject ArmourUp;
    public GameObject EnergyUP;
    public GameObject CapacityUp;

    public Slider slider;
    private int Life = 5;
    private float Coinscore;
    private int Destruct = 200;
    private int maxammo;
    float ratio;
    float ammo;
    float MaxAmmo;
    int GiftCount = 0;
    
    // Start is called before the first frame update
    void Start()
        
    {
        
        GiftCount = PlayerPrefs.GetInt("GiftCount");
        Destruct = PlayerPrefs.GetInt("Destruct");
        MaxAmmo = PlayerPrefs.GetInt("maxammo");
        ammo = PlayerPrefs.GetInt("ammo");
        Debug.Log("giftcount"+ GiftCount);
        if (!(MaxAmmo>200))
        {
           
            // PlayerPrefs.SetInt("ammo", ammo);
            PlayerPrefs.SetInt("maxammo", 200);
        }
      
       //Get max destruction from Register andSign that to ui text
        Maxdestruct.text = Destruct.ToString();
        //Get Coinscore from Register
        Coinscore = PlayerPrefs.GetFloat("Coinscore");
        //Get HighScore And asign that to ui
        highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        //Set Life Value to 5
        PlayerPrefs.SetInt("Life", Life);
        CoinscoreText.text = "Coins : " + ((int)PlayerPrefs.GetFloat("Coinscore")).ToString();
        //Update Life 
        LifeText.text = PlayerPrefs.GetInt("Life").ToString();
        MaxCapacity.text = "Max: " + MaxAmmo.ToString();
        CurCapacity.text = "Current: " + ammo.ToString();
        ratio = (float)ammo /(float)MaxAmmo;
        slider.value = ratio;
        Debug.Log(MaxAmmo);
       
    }
    void Update()
    {
        giftactive();
        showingupdate();

    }
//Upgrates
    public void showingupdate()
    {
        if (Coinscore > 100)
        {
            EnergyUP.SetActive(true);

        }

        if (Coinscore > 250)
        {
            LifeUP.SetActive(true);

        }
        else if (Coinscore > 500)
        {
            ArmourUp.SetActive(true);
        }
        else if (Coinscore > 1000)
        {
            CapacityUp.SetActive(true);

        }
        else
        {
            EnergyUP.SetActive(false);
            LifeUP.SetActive(false);
            ArmourUp.SetActive(false);
            CapacityUp.SetActive(false);
        }

    }
//updat register with values

    public void giftactive(){
        GiftCount = PlayerPrefs.GetInt("GiftCount");
        if (GiftCount == 0)
        {
            CoinSack.SetActive(true);

        }
        else
        {
            CoinSack.SetActive(false);
        }

    }
//AddcoinScore,MAxAmmo,Ammo,armour
    public void AddInitialValues()
    {
        PlayerPrefs.SetInt("GiftCount", 1);
        PlayerPrefs.SetFloat("Coinscore", 1000);
        PlayerPrefs.SetInt("maxammo", 250);
        PlayerPrefs.SetInt("ammo", 250);
        PlayerPrefs.SetInt("Destruct", 250);
        PlayerPrefs.SetFloat("Highscore", 500);
        highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        CoinscoreText.text = "Coins : " + ((int)PlayerPrefs.GetFloat("Coinscore")).ToString();
        CurCapacity.text = "Current: " +  PlayerPrefs.GetInt("ammo").ToString();
        MaxCapacity.text = "Max: " + PlayerPrefs.GetInt("maxammo").ToString();
        Maxdestruct.text = PlayerPrefs.GetInt("Destruct").ToString();
        ratio = (float)PlayerPrefs.GetInt("ammo") / (float)PlayerPrefs.GetInt("maxammo");
        slider.value = ratio;

        

           



    }
   
 //Play Game
    public void ToGame()
    {
        SoundManager.PlaySounds("Click");
        SceneManager.LoadScene("Game");
    }
 //Quit Game
    public void Quit()
    {
        SoundManager.PlaySounds("Click");
        Application.Quit();
        Debug.Log("Quit");
    }
//Adding Life
    public void lifeAdder()
    {
        SoundManager.PlaySounds("Click");
        Coinscore = PlayerPrefs.GetFloat("Coinscore");

        Debug.Log("Coinscore" + Coinscore);
        if (Coinscore > 250)
        {
            Life += 1;

            Debug.Log("Life Added"+Life);
            PlayerPrefs.SetInt("Life", Life);
            Coinscore -= 250;
            PlayerPrefs.SetFloat("Coinscore", Coinscore);
            //update CoinScore 
            CoinscoreText.text = "Coins : " + ((int)PlayerPrefs.GetFloat("Coinscore")).ToString();
            //Update Life 
            LifeText.text = PlayerPrefs.GetInt("Life").ToString();
            //Detuct Coin
            DetuctCoin.text ="-250";
            //ShowDetuction
            DetuctControll();
            NotEnough.SetActive(false);
            
        }
        else
        {
             NotEnough.SetActive(true);

            Debug.Log("Not enough coins");
            PlayerPrefs.SetInt("Life", Life);
            
        }
    }
//increase capacity
 
    public void AddEnergy()
    {
        SoundManager.PlaySounds("Click");
        float Coinscore = PlayerPrefs.GetFloat("Coinscore");
        //PlayerPrefs.SetInt("maxammo", maxammo);
        int MaxAmmo = PlayerPrefs.GetInt("maxammo");
        

        int ammo = PlayerPrefs.GetInt("ammo");
        ratio = (float)ammo / (float)MaxAmmo;
        CurCapacity.text = "Current: " + ammo.ToString();
       

        if ((Coinscore > 100) && (ammo <
            MaxAmmo))
             
        {
            NotEnough.SetActive(false);
            Coinscore = Coinscore - 100;
            PlayerPrefs.SetFloat("Coinscore", Coinscore);
            CoinscoreText.text = "Coins : " + ((int)PlayerPrefs.GetFloat("Coinscore")).ToString();
            CurCapacity.text = "Current: " + ammo.ToString();
            DetuctCoin.text = "-100";
            //ShowDetuction
            DetuctControll();

            if (ammo < MaxAmmo)
            {
                ammo += 10;
                PlayerPrefs.SetInt("ammo", ammo);
                Debug.Log("looooooooooops");
                ratio =(float)ammo / (float)MaxAmmo;
                slider.value = ratio;
                CurCapacity.text = "Current: " + ammo.ToString();
            }
            else
            {
                ammo = MaxAmmo;
                PlayerPrefs.SetInt("ammo", ammo);
                ratio = (float)ammo / (float)MaxAmmo;
                slider.value = ratio;
                CurCapacity.text = "Current: " + ammo.ToString();
            }
        }
        else
        {
            NotEnough.SetActive(true);
        }
    }
    public void incrsMaxAmmo()
    {
        SoundManager.PlaySounds("Click");
        int ammo = PlayerPrefs.GetInt("ammo");
       
        float Coinscore = PlayerPrefs.GetFloat("Coinscore");
        if (Coinscore > 1000)
        {
            NotEnough.SetActive(false);
           
            Coinscore = Coinscore - 1000;
            CoinscoreText.text = "Coins : " + ((int)PlayerPrefs.GetFloat("Coinscore")).ToString();
            PlayerPrefs.SetFloat("Coinscore", Coinscore);
            float MaxAmmo = PlayerPrefs.GetInt("maxammo");
            DetuctCoin.text = "-1000";
            //ShowDetuction
            DetuctControll();
            MaxAmmo += 10;
            maxammo = (int)MaxAmmo;
            PlayerPrefs.SetInt("maxammo", maxammo);
            ratio = ammo / MaxAmmo;
            slider.value = ratio;
            MaxCapacity.text = "Max: " + maxammo.ToString();
        }
        else
        {
            NotEnough.SetActive(false);
            SoundManager.PlaySounds("Click");
        }

    }
    public void DetuctControll()
    {
        Detuct.SetActive(true);
        Invoke("DetuctFalse", 0.2f);
    }
    public void DetuctFalse()
    {
        Detuct.SetActive(false);
    }
    public void IncreeseDestruct()
    {
        SoundManager.PlaySounds("Click");
        float Coinscore = PlayerPrefs.GetFloat("Coinscore");
        if (Coinscore > 500)
        {
            DetuctControll();
            NotEnough.SetActive(false);
            Coinscore -= 500;
            Destruct += 500;
            PlayerPrefs.SetFloat("Coinscore", Coinscore);
            PlayerPrefs.SetInt("Destruct", Destruct);
            DetuctCoin.text = "-500";
            Maxdestruct.text = Destruct.ToString();
            CoinscoreText.text = "Coins : " + ((int)PlayerPrefs.GetFloat("Coinscore")).ToString();
        }
        else
        {
            NotEnough.SetActive(true);
        }
    }
  



}
