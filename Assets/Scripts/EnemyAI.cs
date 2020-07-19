using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 2f;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    [SerializeField] Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {

        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        
        if (isProvoked)
        {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttachTarget();
        } else if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
    }

    private void AttachTarget()
    {
        print("Attacking Player");
        animator.SetTrigger("idle");
        animator.SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        print("detected player");
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
