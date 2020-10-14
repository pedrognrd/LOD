using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Definimos los sonidos del arma
    public AudioClip acShoot;
    public AudioClip acReload;
    public AudioClip acStuck;

    public float cadency; // determina cada cuanto tiempo podemos disparar
    public int maxAmmoByCharger;
    public int maxCharger;
    public int ammo; // munición en el cargador del arma
    public int chargers; // cargadores extras en reserva

    //Accedemos al Audio Source de Arsenal
    public AudioSource audioSource;

    // Variable para determinar si está esperando a que pase el tiempo de cadencia
    private bool isWaiting = false;

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    public void TryShoot()
    {
        if (CanShoot())
        {
            Shoot();
        }
        else
        {
            PlayStuckSound();
        }
    }

    // Definimos el método de recarga
    public void Reload()
    {
        if (chargers > 0)
        {
            PlayReloadSound();
            ammo = maxAmmoByCharger;
            chargers--;
        }
    }

    public virtual void Shoot()
    {
        isWaiting = true;
        Invoke("ReactivarArma", cadency);
        PlayShootSound();
        ammo--;
    }

    public bool CanShoot()
    {
        // ammo > 0 && cadency (al menos 1 segundo entre disparos)
        if (isWaiting == false && ammo > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlayShootSound()
    {
        // Reproduce el sonido del disparo
        audioSource.PlayOneShot(acShoot);
    }

    public void PlayReloadSound()
    {
        audioSource.PlayOneShot(acReload);
    }

    public void PlayStuckSound()
    {
        audioSource.PlayOneShot(acStuck);
    }

    private void ReactivarArma()
    {
        isWaiting = false;
    }
}
