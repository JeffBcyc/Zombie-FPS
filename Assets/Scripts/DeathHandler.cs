using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] Canvas gameOverCanvas;

    private void Awake()
    {
        
        gameOverCanvas.enabled = false;
    }

    public void OnPlayerDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
    }

}
