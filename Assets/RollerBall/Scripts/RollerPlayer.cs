using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RollerPlayer : MonoBehaviour
{
    [SerializeField] float maxForce = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] ForceMode forceMode;
    [SerializeField] Transform viewTransform;

    Rigidbody rb;
    Vector3 force = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //will happen whenever there is a new frame
   void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        //force in world space
        force = direction * maxForce;

        //in view space
        Quaternion viewSpace = Quaternion.AngleAxis(viewTransform.rotation.eulerAngles.y, Vector3.up);
        force = viewSpace * force;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        RollerGameManager.Instance.playerHealth = GetComponent<Health>().health;

    }

    //WILL happen the same number of times per second regardless of framerate
    private void FixedUpdate()
    {
        rb.AddForce(force, forceMode);        
    }
}
