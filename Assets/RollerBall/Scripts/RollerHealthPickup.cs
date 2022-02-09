using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerHealthPickup : RollerPickup, IDestructable
{
    [SerializeField] int heal;
    public void Destroyed()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        go.GetComponent<Health>().health += heal;
    }
}
