using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    [SerializeField] AmmoType ammoType = AmmoType.shells;


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<AmmoBag>().PickUpAmmo(ammoType);
        Destroy(gameObject);
    }


}
