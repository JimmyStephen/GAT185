using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject[] deathPrefabs;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] float maxHealth = 100;
    [SerializeField] bool destroyRoot = false;
    public float health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(TryGetComponent<IDestructable>(out IDestructable destructable))
            {
                destructable.Destroyed();
            }

            if(deathPrefabs != null)
            {
                foreach (GameObject deathPrefab in deathPrefabs)
                {
                    Instantiate(deathPrefab, transform.position, transform.rotation);
                }
            }

            if (destroyOnDeath)
            {
                if (destroyRoot) Destroy(gameObject.transform.root.gameObject);
                else Destroy(gameObject);
            }
        }else if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }
}
