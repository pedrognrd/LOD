﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBGShell : MonoBehaviour
{
    public int danyo = 25;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); 
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<Enemy>().DamageReceived(danyo);
        }
    }
}
