using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaGranadas : Weapon
{
    public float force;
    public GameObject prefabProyectil;
    public Transform transformSpawner;

    public override void Shoot()
    {
        base.Shoot();
        GameObject proyectil = Instantiate(prefabProyectil, transformSpawner.position, transformSpawner.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(transformSpawner.forward * force);
    }
}
