using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float enemyHealth = 100f;
    public bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    //private void Awake()
    //{
    //    isDead = false;
    //}

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        enemyHealth -= damage;
        if(enemyHealth<=0) 
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }


}
