using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int playerHealth = 100;
    public enum PlayerStatus
    {
        Alive,
        Dead
    }

    private void Awake()
    {
        currentStatus = PlayerStatus.Alive;
    }

    public PlayerStatus currentStatus;

    public void PlayerTakeDamage(int incomingDamge)
    {
        playerHealth -= incomingDamge;
        print("you have " + playerHealth + " health left, be careful!");
        if (playerHealth <= 0)
        {
            currentStatus = PlayerStatus.Dead;
            GetComponent<DeathHandler>().OnPlayerDeath();
        }
    }



}
