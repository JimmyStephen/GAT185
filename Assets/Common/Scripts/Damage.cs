using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 0;
    [SerializeField] bool oneTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Health>(out Health health) && oneTime)
        {
            health.Damage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<Health>(out Health health) && !oneTime)
        {
            health.Damage(damage * Time.deltaTime);
        }
    }
}
