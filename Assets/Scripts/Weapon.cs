using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Weapon : MonoBehaviour
{

    [SerializeField] float shootingRange = 100f;
    [SerializeField] float weaponDamage = 10f;
    [SerializeField] ParticleSystem gunFlare;
    [SerializeField] GameObject hitEffect;

    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] WeaponZoom weaponZoom;

    [SerializeField] AmmoBag ammobag;
    [SerializeField] AmmoType ammoType;


    [SerializeField] float firingRate = 0.25f;
    [SerializeField] float nextFire;

    [SerializeField] int weaponIndex;

    

    public int WeaponIndex()
    {
        return weaponIndex;
    }

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        weaponZoom = FindObjectOfType<WeaponZoom>();
        ammobag = FindObjectOfType<AmmoBag>();
    }

    private void Update()
    {
        if (playerHealth.currentStatus == PlayerHealth.PlayerStatus.Alive)
        {
            if (Input.GetMouseButton(0) & Time.time > nextFire)
            {
                nextFire = Time.time + firingRate;
                Shoot();
            }
            else if (Input.GetMouseButton(1))
            {
                weaponZoom.WeaponZoomIn();
            }
            else
            {
                weaponZoom.WeaponZoomOut();
            }

        }
    }

    private void Shoot()
    {
        if (ammobag.GetAmmoNumber(ammoType) >0)
        {
            ActivateVFX();
            ShootingBullet();
            ammobag.DecreaseAmmo(ammoType);
        } else
        {
            print("Out of Ammo");
        }
    }

    private void ActivateVFX()
    {
        gunFlare.Play();
    }


    private void ShootingBullet()
    {
        RaycastHit _hit;
        print("1 Shot");
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hit, shootingRange))
        {
            float weaponDamagePlus = weaponDamage;
            CreateHitEffect(_hit);
            EnemyHealth enemyHealth = _hit.transform.GetComponent<EnemyHealth>();
            if (! (enemyHealth == null)) 
            {  
            enemyHealth.TakeDamage(weaponDamagePlus);
            }
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject _impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        _impact.SetActive(true);
        Destroy(_impact, _impact.GetComponentInChildren<ParticleSystem>().main.duration);    
    }
}
