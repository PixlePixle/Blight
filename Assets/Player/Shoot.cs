using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    Vector3 destination;
    Controls controls;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    float projectileSpeed = 30f;

    private void OnEnable()
    {
        controls = new Controls();
        controls.Movement.Shoot.performed += _ => Fire();
        controls.Enable();
    }

    private void Fire()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        destination = ray.GetPoint(3f);
        destination.y = firePoint.transform.position.y;
        InstatiateProjectile();
    }

    void InstatiateProjectile()
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
