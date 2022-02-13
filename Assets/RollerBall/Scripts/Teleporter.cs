using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject[] location;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = location[Random.Range(0, location.Length)].transform.position;
    }
}
