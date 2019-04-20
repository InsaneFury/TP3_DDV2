using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI ScoreText;

    private void Start() 
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ScoreText.text = GameManager.Instance.score.ToString();
    }
}
