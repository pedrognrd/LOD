using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBarrelGun : Weapon
{
    public float force;
    public GameObject prefabProyectil;
    public Transform transformSpawner;
    private int damageDone = 25;

    /*public override void Shoot()
    {
        base.Shoot();
        GameObject proyectil = Instantiate(prefabProyectil, transformSpawner.position, transformSpawner.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(transformSpawner.forward * force);
    }*/

    public override void Shoot()
    {
        base.Shoot();
        //Lanzamos el rayo desde el punto en el que está la cámara
        RaycastHit hit;
        // Para ello cogemos el objeto con el tag "MainCamera"
        Vector3 origen = Camera.main.transform.position;
        // De ahí, cogemos la posición y marcamos una dirección
        Vector3 direccion = Camera.main.transform.forward;

        // Lanzamos el raycast
        // "out" indica que la variable "hit", se modificará cuando el Raycast impacto contra algo
        if (Physics.Raycast(origen, direccion, out hit))
        {
            // Enra si choca contra algo
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                hit.transform.gameObject.GetComponentInParent<Enemy>().DamageReceived(damageDone);
            }
        }
    }

}
