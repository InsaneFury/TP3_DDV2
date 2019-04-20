using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance 
    {
        get 
        {
            return instance;
        }
    }

    [Header("UI")]
    public int score = 00;
    public bool gameOver;

    private void Awake() 
        {
        //Singleton
        if(instance != null) 
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //Cursor State
        if (SceneManager.GetActiveScene().name == "GameOver") 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (SceneManager.GetActiveScene().name == "Gameplay") 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Start()
    {
        gameOver = false;
        score = 00;
    }

    void Update()    
    {
        if (gameOver) 
        {
            Invoke("GameOverScene", 1f);
            gameOver = false;
        }
    }

    //Scenes Functions
    public void NextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GameOverScene() 
    {
        SceneManager.LoadScene("GameOver");
    }
}
