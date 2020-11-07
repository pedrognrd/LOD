using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Animator animator;
    private float currentSpeed;
    [SerializeField]
    private int increaseSpeed;
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
        // Calling to Rotate at start and every timeBetweenRotation
        InvokeRepeating("Rotate", 0, timeBetweenRotation);
    }

    public override void Attack()
    {
        print("script skeleton " + skeletonSword.GetComponent<SkeletonSword>().canAttack);
        if (skeletonSword.GetComponent<SkeletonSword>().canAttack)
        {
            print("script skeleton en el if " + skeletonSword.GetComponent<SkeletonSword>().canAttack);
            print("canAttack " + skeletonSword.GetComponent<SkeletonSword>().canAttack);
            print("collisionable " + skeletonSword.GetComponent<SkeletonSword>().collisionable);
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
        transform.Rotate(0, Random.Range(minDegreeRotation, maxDegreeRotation), 0);
    }
}
