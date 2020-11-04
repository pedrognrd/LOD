using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilFisico : MonoBehaviour
{
    [SerializeField]
    public int danno;
    [SerializeField]
    private float timeToDestroy;

    private void Start()
    {
        //destruimos el proyectil al superar el tiempo de timeToDestroy
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy de = collision.gameObject.GetComponent<Enemy>();
            de.DamageReceived(danno, transform.position);
            Destroy(gameObject);
        }
    }
}
