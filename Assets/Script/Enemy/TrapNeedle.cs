using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNeedle : MonoBehaviour
{
    [Header("Trap Settings")]
    public float trapDamage = 50f;
    public GameObject player;
    public float forceToPushPlayer = 1000f;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnCollisionEnter(Collision c) 
    {

        if (c.collider.CompareTag("Player")) 
        {
            player.GetComponent<Player>().impulseBackward(forceToPushPlayer);
            DamagePlayer();
        }
    }

    public void DamagePlayer() {
        player.GetComponent<Player>().takeDamage(trapDamage);
    }
}
