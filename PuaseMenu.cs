using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuaseMenu : MonoBehaviour{
    private int Life = 5;
    public GameObject pauseMenu;
    void Start()
    {
        //Deactivate Pause Menu
        gameObject.SetActive(false);
       
    }


    
    //Restart Game
    public void Restart()
    {

        SceneManager.LoadScene("game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Life", Life);
        SoundManager.PlaySounds("Click");
    }
    //Back to main menu
    public void ToMenu()
    {
        SceneManager.LoadScene("characters");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SoundManager.PlaySounds("Click");

    }
    //Paused the game
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.PlaySounds("Click");
    }
    //Resume Game
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SoundManager.PlaySounds("Click");
    }
    //Quit Game
    public void QuitGame()
    {
        Application.Quit();
        SoundManager.PlaySounds("Click");
    }
}
