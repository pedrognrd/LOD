using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton1 : Enemy
{
    [SerializeField]
    private float timeBetweenRotation;
    [SerializeField]
    private float minDegreeRotation;
    [SerializeField]
    private float maxDegreeRotation;

    private void Start()
    {
        // Calling to Rotate at start and every timeBetweenRotation
        InvokeRepeating("Rotate", 0, timeBetweenRotation);
    }

    public override void Attack()
    {
        player.GetComponent<PlayerManager>().DamageReceived(damageDone);
        Dying(autodestruccion = false);
    }

    public override void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void Rotate()
    {
        transform.Rotate(0, Random.Range(minDegreeRotation, maxDegreeRotation),0);
    }
}
