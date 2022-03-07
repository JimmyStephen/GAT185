using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 0;
    [SerializeField] bool oneTime = true;
    [SerializeField] string[] avoidTags;

    private void OnTriggerEnter(Collider other)
    {
        print("On Trigger Enter: " + other.gameObject.name);
        if (avoidTags.Length != 0)
        {
            foreach (string tag in avoidTags)
            {
                if (tag == other.tag) return;
            }
        }

        if(other.gameObject.TryGetComponent<Health>(out Health health) && oneTime)
        {
            health.Damage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        print("On Trigger Stay: " + other.gameObject.name);
        if (avoidTags.Length != 0)
        {
            foreach (string tag in avoidTags)
            {
                if (tag == other.tag) return;
            }
        }

        if (other.gameObject.TryGetComponent<Health>(out Health health) && !oneTime)
        {
            health.Damage(damage * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("On Collision Enter: " + collision.gameObject.name);
        if (avoidTags.Length != 0)
        {
            foreach (string tag in avoidTags)
            {
                if (tag == collision.gameObject.tag) return;
            }
        }

        if (collision.gameObject.TryGetComponent<Health>(out Health health) && oneTime)
        {
            health.Damage(damage);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        print("On Collision Stay: " + collision.gameObject.name);
        if (avoidTags.Length != 0)
        {
            foreach (string tag in avoidTags)
            {
                if (tag == collision.gameObject.tag) return;
            }
        }

        if (collision.gameObject.TryGetComponent<Health>(out Health health) && !oneTime)
        {
            health.Damage(damage * Time.deltaTime);
        }
    }
}
