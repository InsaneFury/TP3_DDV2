using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    public float timeToRevive = 5f;

    public void TakeDamage(float amount) {
        health -= amount;
        if(health <= 0f) {
            Die();
        }
    }

    void Die() {
        StartCoroutine(Revive(timeToRevive));
    }

    public IEnumerator Revive(float timeToRevive) {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(timeToRevive);
        gameObject.SetActive(true);
        StopCoroutine("Revive");
    }
}
