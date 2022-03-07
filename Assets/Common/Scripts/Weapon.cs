using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] string activeAnimation;
    [SerializeField] string actionAnimation;
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] Transform spawnTransform;
    [SerializeField] BoxCollider bCollider;

    public override void Activate()
    {
        visual.SetActive(true);
        if (!string.IsNullOrEmpty(activeAnimation)) animator.SetBool(activeAnimation, true);
        if (bCollider != null) bCollider.enabled = false;
    }
    public override void Deactivate()
    {
        visual.SetActive(false);
        if (!string.IsNullOrEmpty(activeAnimation)) animator.SetBool(activeAnimation, false);
        if (!string.IsNullOrEmpty(activeAnimation)) StopFire();
        if(bCollider != null) bCollider.enabled = false;
    }

    //update loop
    public override void UpdateItem()
    {
        if (Input.GetButtonDown(input)) StartFire();
        if (Input.GetButtonUp(input)) StopFire();
    }

    private void StartFire()
    {
        animator.SetBool(actionAnimation, true);
        if (bCollider != null) bCollider.enabled = true;
    }

    private void StopFire()
    {
        animator.SetBool(actionAnimation, false);
        if (bCollider != null) bCollider.enabled = false;
    }

    public void Fire()
    {
        Instantiate(ammoPrefab, spawnTransform.position, spawnTransform.rotation);
    }
}
