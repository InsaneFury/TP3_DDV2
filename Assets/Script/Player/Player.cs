using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI life_text;
    public float life = 100f;
    bool isPlaying = true;

    void Start()
    {
        life_text.text = life.ToString();
    }

    private void Update() 
    {
        life_text.text = life.ToString();
        if(life <= 0f && isPlaying) 
        {
            isPlaying = false;
            //GetComponent<Rigidbody>().isKinematic = true;
            GameManager.Instance.gameOver = true;
        }
    }

    public void takeDamage(float dmg) 
    {   
        if (life >= 0f) 
        {
            life -= dmg;
        }
        if(life < 0f) 
        {
            life = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("trap")) ;
        impulseBackward(500f);
    }

    public void impulseBackward(float impulse) {
        GetComponent<Rigidbody>().AddForce(Vector3.back * impulse);
    }
}
