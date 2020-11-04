using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    public GameObject prefabExplosion;
    public float ratioExplosion;
    public int danyo = 50;

    private void OnCollisionEnter(Collision collision)
    {
        // Generamos una lista de colliders para ver si alguno de ellos impactaría en el enemigo u objeto
        Collider[] colliders = Physics.OverlapSphere(transform.position, ratioExplosion);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.CompareTag("Enemy")) {
                c.gameObject.GetComponentInParent<Enemy>().DamageReceived(danyo);
            }
        }
        Instantiate(prefabExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
    