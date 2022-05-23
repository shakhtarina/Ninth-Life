using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Pause : MonoBehaviour
{
    public bool PauseGame = false;
    public GameObject pauseGameMenu ;

    void Start()
    {
        PauseGame = false;
        Time.timeScale = 1;
        pauseGameMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause_();
            }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Options()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    void Pause_()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;

    }
    
    public void LosdMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }


}

