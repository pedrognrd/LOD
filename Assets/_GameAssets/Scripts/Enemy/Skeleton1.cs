using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Skeleton1 : Enemy
{
    public Animator animator; 
    private float currentSpeed;
    [SerializeField]
    private int increaseSpeed;
    //private float lastSpeed;
    [SerializeField]
    private float maxDegreeRotation;
    [SerializeField]
    private float minDegreeRotation;
    [SerializeField]
    private float timeBetweenRotation;
    [SerializeField]
    GameObject skeletonSword;
    

    private void Start()
    {
        //lastSpeed = speed;
        // Calling to Rotate at start and every timeBetweenRotation

        InvokeRepeating("Rotate", 0, timeBetweenRotation);
    }

    public override void Attack()
    {
        if (skeletonSword.GetComponent<Skeleton1Sword>().canAttack) 
        {
            player.GetComponent<PlayerManager>().DamageReceived(damageDone);
        }
        //Dying(autodestruccion = false);
    }

    public override void Move()
    {
        // Posición del player con la Y del enemigo. Para evitar que el enemigo se incline al estar muy cerca del player
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        
        if (DistanceToPlayer() <= followingDistance)
        {
            transform.LookAt(target);
            //currentSpeed = speed * increaseSpeed;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void Rotate()
    {
        transform.Rotate(0, Random.Range(minDegreeRotation, maxDegreeRotation),0);
    }
}
