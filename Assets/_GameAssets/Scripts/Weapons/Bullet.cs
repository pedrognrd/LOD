using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int danyo = 50;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<Enemy>().DamageReceived(danyo);
        }
    }
}
