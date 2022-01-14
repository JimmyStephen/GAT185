using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10)][Tooltip("Speed of the player")]public float speed = 5;
    [SerializeField] AudioSource audioSource;

/*    private void Awake()
    {
        print("Awake");
    }
    private void Start()
    {
        print("Start");
    }*/

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        //GetComponent<Transform>() => transform
        transform.position += direction * speed * Time.deltaTime;
        
        
        //transform.localScale = new Vector3(2, 2, 2);

        if (Input.GetButton("Fire1"))
        {
            //transform.rotation *= Quaternion.Euler(5,0,0);
            //audioSource.Play();
            GetComponent<Renderer>().material.color = Color.green;
        }

/*        GameObject go = GameObject.Find("Cube");
        if (go)
        {
            go.GetComponent<Renderer>().material.color = Color.cyan;
        }*/
    }
}
