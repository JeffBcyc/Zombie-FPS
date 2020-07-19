using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    private Vector3 initialPlace;
    private void Awake()
    {
        initialPlace = transform.position;
    }

    private void Update()
    {
       transform.position += new Vector3(1f, 0, 1f);
    }

}
