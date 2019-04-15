using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int points = 100;

    public void TakeDamage(float amount) {
        health -= amount;
        if(health <= 0f) {
            Die();
        }
    }

    void Die() {
        FindObjectOfType<GameManager>().score += points;
        gameObject.SetActive(false);
    }
}
