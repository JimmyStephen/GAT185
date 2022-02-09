using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoin : RollerPickup, IDestructable
{
    public int score;

    public void Destroyed()
    {
        RollerGameManager.Instance.Score += score;
    }
}
