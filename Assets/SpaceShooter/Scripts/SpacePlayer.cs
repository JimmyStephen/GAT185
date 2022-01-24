using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour, IDestructable
{
    [Range(0, 100)] [Tooltip("Speed of the player")] public float speed = 40;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        transform.Translate(direction * speed * Time.deltaTime);
        //transform.position += direction * speed * Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            GetComponent<SpaceWeapon>().Fire();
        }
    }

    public void Destroyed()
    {
        GameManager.Instance.OnStartTitle();
    }
}
