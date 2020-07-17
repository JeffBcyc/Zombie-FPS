using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class weapon : MonoBehaviour
{

    [SerializeField] float shootingRange = 100f;
    [SerializeField] float weaponDamage = 10f;
    [SerializeField] ParticleSystem gunFlare;
    [SerializeField] GameObject hitEffect;

    [SerializeField] PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if (playerHealth.currentStatus == PlayerHealth.PlayerStatus.Alive)
        {

            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
            else if (Input.GetMouseButton(1))
            {
                print("Player pressed right button");
            }
        }
    }

    private void Shoot()
    {
        ActivateVFX();
        Bullets();

    }

    private void ActivateVFX()
    {
        gunFlare.Play();
    }

    private void Bullets()
    {
        RaycastHit _hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hit, shootingRange))
        {
            float weaponDamagePlus = weaponDamage * Time.deltaTime * 10f;
            CreateHitEffect(_hit);
            EnemyHealth enemyHealth = _hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth == null) { return; }
            enemyHealth.TakeDamage(weaponDamagePlus);

        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject _impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        _impact.SetActive(true);
        Destroy(_impact, _impact.GetComponentInChildren<ParticleSystem>().main.duration);    
    }
}
