using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] int damage = 10;

    PlayerHealth playerHealth;


    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        playerHealth = target.GetComponent<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        playerHealth.PlayerTakeDamage(damage);
    }

    //public void OnDamageTaken()
    //{
    //    print("I also invoked damaged");
    //}

}
