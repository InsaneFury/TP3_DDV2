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
        if (GameObject.FindGameObjectWithTag("Score")) {
            ScoreTextFound = GameObject.FindGameObjectWithTag("Score");
            scoreText = ScoreTextFound.GetComponent<TextMeshProUGUI>();
        }
        else {
            ScoreTextFound = null;
            scoreText = null;
        }
        gameOver = false;
        score = 0;
    }

    private void Update() {
        if (scoreText) {
            scoreText.text = score.ToString();
        }
    }

    //Scenes Functions
    public void NextScene() {
        SceneManager.LoadScene("Gameplay");
    }
}
