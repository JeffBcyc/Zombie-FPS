using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int initialWeaponIndex = 1;
    [SerializeField] int _weaponIndex = 1;
    private void Start()
    {
        SetWeaponActive(initialWeaponIndex);
    }

    private void SetWeaponActive(int weaponIndex)
    {
        foreach (Transform weapon in transform)
        {
            if (weapon.GetComponent<Weapon>().WeaponIndex() == weaponIndex)
            {
                weapon.gameObject.SetActive(true);
            } else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        SwitchWeaponKeyboard();
        SwitchWeaponMouseScroll();
        
        SetWeaponActive(_weaponIndex);
    }

    private void SwitchWeaponMouseScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_weaponIndex >= transform.childCount)
            {
                _weaponIndex = initialWeaponIndex;
            } else
            {
                _weaponIndex++;
            }
            print(_weaponIndex);
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_weaponIndex <= initialWeaponIndex)
            {
                _weaponIndex = transform.childCount;
            }
            else
            {
                _weaponIndex --;
            }
        }
    }

    private void SwitchWeaponKeyboard()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            print("2 pressed");
            _weaponIndex = 1;
        } else if (Input.GetKey(KeyCode.Alpha2))
        {
            print("3 pressed");
            _weaponIndex = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            print("3 pressed");
            _weaponIndex = 3;
        }

    }
}
