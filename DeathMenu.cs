using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private int DeathLife = 5;
    public Text scoreText;
    public Image backgroundImg;
   
    private int Life = 5;
   
    
    

    private bool isShowned = false;

    private float transition = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
       
      
       

    }
    // Update is called once per frame
    void Update()
    {
        if (!isShowned)
            return;

        transition += Time.deltaTime/8;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }
    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShowned = true;
    }
    public void Restart()
    {

        SceneManager.LoadScene("game");
        PlayerPrefs.SetInt("Life", Life);
        SoundManager.PlaySounds("Click");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("characters");
        PlayerPrefs.SetInt("Life", DeathLife);
        SoundManager.PlaySounds("Click");
    }
}

