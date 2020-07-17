using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBag : MonoBehaviour
{

    [SerializeField] int ammoutAmount = 10;

    public int GetCurrentAmmo()
    {
        return ammoutAmount;
    }

    public void DecreaseAmmo()
    {
        ammoutAmount--;
    }

}
