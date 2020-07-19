using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBag : MonoBehaviour
{

    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoNum;
    }

    public void PickUpAmmo(AmmoType ammoType)
    {
        GetCurrentAmmo(ammoType).ammoNum++;
    }

    private AmmoSlot GetCurrentAmmo(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }



    public void DecreaseAmmo(AmmoType ammoType)
    {
        GetCurrentAmmo(ammoType).ammoNum --;   
    }


    public int GetAmmoNumber(AmmoType ammoType)
    {
       return GetCurrentAmmo(ammoType).ammoNum;
    }



}
