using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [Header("Variables")]
    public float dmg = 1f;
    public float rangeOfSpawn = 100f;
    public float rangeOfDamage = 5f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public float impactForce = 50f;
    public float bulletsToShoot = 30f;
    float defaultBullets;
    public float munitionToLoad = 100f;

    [Header("Cam & VFX")]
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject bulletImpactFX;

    [Header("UI")]
    public GameObject reloadText;
    public TextMeshProUGUI actualBullets;
    public TextMeshProUGUI munition;

    private void Start() {
        defaultBullets = bulletsToShoot;
    }

    // Update is called once per frame
    void Update() {
        if (!FindObjectOfType<GameManager>().gameOver) {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && bulletsToShoot > 0f) {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
            else if (Input.GetButton("Fire1") && bulletsToShoot <= 0f && Time.time >= nextTimeToFire) {
                reloadText.SetActive(true);
                //Call sound FX
                FindObjectOfType<AudioManager>().Play("noAmmo");
            }

            //Zoom
            if (Input.GetButton("Fire2")) {
                fpsCam.fieldOfView = 40f;
                GameObject.FindGameObjectWithTag("crosshair").GetComponent<RectTransform>().localScale = (new Vector3(0.8f, 0.8f, 1f));
            }
            else {
                fpsCam.fieldOfView = 70f;
                GameObject.FindGameObjectWithTag("crosshair").GetComponent<RectTransform>().localScale = (new Vector3(1f, 1f, 1f));
            }

            //Reload
            if (Input.GetKeyDown(KeyCode.R)) {
                if (munitionToLoad >= defaultBullets) {
                    bulletsToShoot = defaultBullets;
                    munitionToLoad -= defaultBullets;
                    reloadText.SetActive(false);
                    //Call sound FX
                    FindObjectOfType<AudioManager>().Play("reload");
                }
                else {
                    bulletsToShoot = munitionToLoad;
                    munitionToLoad = 000f;
                    reloadText.SetActive(false);
                    //Call sound FX
                    FindObjectOfType<AudioManager>().Play("reload");
                }
            }
            actualBullets.text = bulletsToShoot.ToString();
            munition.text = munitionToLoad.ToString();
        }
        
    }

    public void Shoot() {
        //Call sound FX
        FindObjectOfType<AudioManager>().Play("shoot");
        bulletsToShoot--;
        muzzleFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit, rangeOfSpawn)) {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null && hit.distance <= rangeOfDamage) {
                target.TakeDamage(dmg);  
            }
            
            GameObject go = Instantiate(bulletImpactFX, hit.point, Quaternion.LookRotation(hit.normal));
            //Call sound FX
            FindObjectOfType<AudioManager>().Play("bullet_impact");
            Destroy(go, 2f);
        }
    }
}
