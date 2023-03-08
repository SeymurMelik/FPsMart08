using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera FpsCam;
    public ParticleSystem MuzzleFlash;
    public AudioSource ShotSound;

    public Text CurrentAmmoDisplay;
    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    private void Update()
    {
        CurrentAmmoDisplay.text = currentAmmo.ToString();
        if (isReloading) return;

        if (currentAmmo !=10 && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            MuzzleFlash.Play();

            currentAmmo--;

            ShotSound.Play();
            RaycastHit hit;
            if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ammo")
        {
            currentAmmo = maxAmmo;
        }
    }
}
