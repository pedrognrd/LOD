using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimated : Skeleton
{
    //public Animator animator;
    private float lastSpeed;
    private void Start()
    {
        lastSpeed = speed;
    }
    protected override void Update()
    {
        base.Update();
        EvaluarEstadoAnimacion();
    }

    private void EvaluarEstadoAnimacion()
    {
        // Posición del player con la Y del enemigo. Para evitar que el enemigo se incline al estar muy cerca del player
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (DistanceToPlayer() <= attackDistance)
        {
            // Reducimos su velocidad
            speed = 0;
            // Se acerca hasta detenerse y comienza a atacar
            animator.SetBool("Iddle", true);
            animator.SetTrigger("AttackTrigger");
        }

        if (DistanceToPlayer() > attackDistance)
        {
            // Recuperamos la velocidad inicial
            speed = lastSpeed;
            // Deja de atacar y comienza a andar
            animator.ResetTrigger("AttackTrigger"); 
            animator.SetBool("Iddle", false);
        }

    }
}
