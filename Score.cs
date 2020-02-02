using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    //private float Coins =0;

    private int difficultyLevel = 1;
    private int maxdifficultyLevel =100;
    private int scoreToNextLevel = 100;

    private bool isDead = false;
    float highscore;
    int HighCount = 0;

    public Text scoreText;
    //public Text coinText;
    //public Text LastcoinText;
    public DeathMenu deathMenu;
    public HighScoreText highscoretext;
    public Text HighScore;



    void Start()
    {
       highscore = PlayerPrefs.GetFloat("Highscore");
       // Coins = PlayerPrefs.GetFloat("Coinscore");
    }
    
   
 // Update is called once per frame
    void Update()
    {
       // Coins += Time.deltaTime;
        if (isDead)
            return;


        if (score >= scoreToNextLevel)
            LevelUp();

        score += Time.deltaTime*10;
        if ((score > highscore)&&(HighCount < 1))
        {
            HighCount += 1;
            highscoretext.ToggleHichScoreTextOn();
            //Invoke("HighScoreOff", 0.1f);
        }
        
        scoreText.text = ((int)score).ToString();
       // coinText.text = ((int)Coins).ToString();
        //LastcoinText.text = ((int)Coins).ToString();
    }
    void LevelUp()
    {
        if (difficultyLevel == maxdifficultyLevel)
            return;
        scoreToNextLevel +=250;
        difficultyLevel++;
        GetComponent<Playerv1>().SetSpeed(difficultyLevel);
        Debug.Log(difficultyLevel);
    }
    public void OnDeath(){
        isDead = true;
       // PlayerPrefs.SetFloat("Coinscore", Coins);

        if (PlayerPrefs.GetFloat("Highscore") < score)
        PlayerPrefs.SetFloat("Highscore", score);
        HighScore.text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
       
        

        deathMenu.ToggleEndMenu(score);
 
    }
   public void HighScoreOff()
   {
       highscoretext.ToggleHichScoreTextOff();
   }
}
