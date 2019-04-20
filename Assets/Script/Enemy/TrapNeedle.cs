using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNeedle : MonoBehaviour
{
    [Header("Trap Settings")]
    public float trapDamage = 50f;
    public GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnCollisionEnter(Collision c) 
    {

        if (c.collider.CompareTag("Player")) 
        {
            DamagePlayer();
        }
    }

    public void DamagePlayer() {
        player.GetComponent<Player>().takeDamage(trapDamage);
    }
}
