using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI life_text;
    public GameObject gameOver;
    public float life = 100f;
    void Start()
    {
        life_text.text = life.ToString();
    }

    private void Update() {
        life_text.text = life.ToString();
        if(life <= 0f) {
            gameOver.SetActive(true);
            FindObjectOfType<GameManager>().gameOver = true;
            gameObject.GetComponent<CharacterController>().enabled = false;
        }
    }

    public void takeDamage(float dmg) {
        if (life >= 0f) {
            life -= dmg;
        }
        if(life < 0f) {
            life = 0f;
        }
    }
}
