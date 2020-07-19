using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomIn = 60f;
    [SerializeField] float zoomOut = 60f;

    [SerializeField] RigidbodyFirstPersonController playerRig;
    [Range(1,10)][SerializeField] float zoomInSens = 1f;
    [Range(1, 10)] [SerializeField] float zoomOutSens = 10f;


    private void Start()
    {
        playerRig = GetComponent<RigidbodyFirstPersonController>();
    }

    public void WeaponZoomIn()
    {
        Camera.main.fieldOfView = zoomIn;
        playerRig.mouseLook.XSensitivity = zoomInSens;
        playerRig.mouseLook.YSensitivity = zoomInSens;
    }

    public void WeaponZoomOut()
    {
        Camera.main.fieldOfView = zoomOut;
        playerRig.mouseLook.XSensitivity = zoomOutSens;
        playerRig.mouseLook.YSensitivity = zoomOutSens;

    }

}
