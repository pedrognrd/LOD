using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class SkeletonSword : MonoBehaviour
{
    public bool collisionable = true;
    public bool canAttack = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collisionable) {
            collisionable = false;
            canAttack = true;
            Invoke("StopAttack", 0.02f);
            Invoke("ReactivarColision", 2);
        }
    }

    public void StopAttack()
    {
        canAttack = false;
    }
    public void ReactivarColision() 
    {
        collisionable = true;
    }
}
