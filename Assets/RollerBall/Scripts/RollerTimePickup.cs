using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerTimePickup : RollerPickup, IDestructable
{
    [SerializeField] int timeToAdd;
    public void Destroyed()
    {
        RollerGameManager.Instance.GameTime += timeToAdd;
    }
}
