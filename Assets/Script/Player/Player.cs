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
    public float impulseOfTrap = 10f;

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
            GetComponent<Rigidbody>().isKinematic = true;
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

    public void impulseBackward(float impulse, Vector3 dir) {
        GetComponent<Rigidbody>().AddForce(dir * impulse * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision c) 
    {
        if (c.collider.CompareTag("needle")) 
        {
            //Get Direction Vector trap to player
            Vector3 Dir = transform.position - c.GetContact(0).point;
            // We then get the opposite (-Vector3) and normalize it
            Dir = -Dir.normalized;
            impulseBackward(impulseOfTrap,Dir);
        }
    }

    
}
