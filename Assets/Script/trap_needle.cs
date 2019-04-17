using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_needle : MonoBehaviour
{
    public float trap_damage = 50f;
    public GameObject Player;
    public bool waitToEndAnim;

    private void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        waitToEndAnim = true;
    }
    private void Update() {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Invoke("DamagePlayer",1f);
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            Invoke("DamagePlayer", 5f);
        }
    }
    public void DamagePlayer() {
        Player.GetComponent<Player>().takeDamage(trap_damage);
    }
}
