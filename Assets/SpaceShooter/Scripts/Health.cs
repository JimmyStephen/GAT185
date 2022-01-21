using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject[] deathPrefabs;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] float maxHealth = 100;
    public float health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(tag == "Player")
        {
            //GameManager.Instance.Health -= damage;
        }
        if(health <= 0)
        {
            if (tag != "Projectile" && tag != "Player")
            {
                GameManager.Instance.Score += 100;
            }

            if(deathPrefabs != null)
            {
                foreach (GameObject deathPrefab in deathPrefabs)
                {
                    Instantiate(deathPrefab, transform.position, transform.rotation);
                }
            }

            if(tag == "Player")
            {
                GameManager.Instance.OnStartTitle();
            }

            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
        }
    }
}
