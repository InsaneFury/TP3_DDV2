using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 00;
    public TextMeshProUGUI scoreText;
    public bool gameOver;

    void Start()
    {
        gameOver = false;
        score = 0;
    }

    private void Update() {
        scoreText.text = score.ToString();
    }
}
