using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    Canvas gameOverCanvas;

    private void Awake()
    {
        gameOverCanvas = FindObjectOfType<Canvas>();
        gameOverCanvas.enabled = false;
    }

    public void OnPlayerDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
