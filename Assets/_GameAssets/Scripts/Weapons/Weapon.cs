using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Definimos los sonidos del arma
    public AudioClip acShoot;
    public AudioClip acReload;
    public AudioClip acStuck;
    // Munición en el cargador del arma
    public int ammo; 
    //Accedemos al Audio Source de Arsenal
    public AudioSource audioSource;
    // Determina cada cuanto tiempo podemos disparar
    public float cadency;
    // Cargadores extras en reserva
    public int chargers; 
    protected GameObject enemy; 
    // Variable para determinar si está esperando a que pase el tiempo de cadencia
    private bool isWaiting = false;
    public int maxAmmoByCharger;
    public int maxCharger;
    //public Text textChargers;

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //print(enemy);
        //Vector3 direccion = enemy.transform.position - transform.position;
        //Debug.DrawRay(transform.position, direccion, Color.red, 0.1f);
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

    /*private void RefreshUI()
    {
        textChargers.text = "x" + chargers.ToString();
    }*/
    public virtual void Reload()
    {
        if (chargers > 0)
        {
            PlayReloadSound();
            //RefreshUI();
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
