using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() {
        if(instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Header("UI")]
    public int score = 00;
    public TextMeshProUGUI scoreText;
    public bool gameOver;
    GameObject ScoreTextFound;

    void Start()
    {
        InitGameObjects();
        gameOver = false;
        score = 0;
    }

    private void Update() {
        if (gameOver) {
            Invoke("GameOverScene", 2f);
            gameOver = false;
        }
        if (scoreText) {
            scoreText.text = score.ToString();
        }
    }

    //Scenes Functions
    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GameOverScene() {
        
        SceneManager.LoadScene("GameOver");
    }

    void InitGameObjects() {
        if (GameObject.FindGameObjectWithTag("Score")) {
            ScoreTextFound = GameObject.FindGameObjectWithTag("Score");
            scoreText = ScoreTextFound.GetComponent<TextMeshProUGUI>();
        }
    }
}
