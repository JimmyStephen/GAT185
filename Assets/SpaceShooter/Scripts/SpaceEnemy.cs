using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemy : MonoBehaviour, IDestructable
{
    [SerializeField] SpaceWeapon spaceWeapon;
    [SerializeField] float minFireTime;
    [SerializeField] float maxFireTime;

    public int points;
    private float timer;

    private void Start()
    {
        timer = Random.Range(minFireTime, maxFireTime);
    }

    private void Update()
    {
        if (!spaceWeapon) return;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = Random.Range(minFireTime, maxFireTime);
            spaceWeapon.Fire();
        }
        
    }

    public void Destroyed()
    {
        if (tag != "Projectile" && tag != "Player")
        {
            GameManager.Instance.Score += points;
        }
    }
}
