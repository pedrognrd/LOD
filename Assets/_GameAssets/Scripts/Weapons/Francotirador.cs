using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Francotirador : Weapon
{
    public GameObject scopeImage;
    public GameObject healthBar;
    public GameObject gun;
    public FirstPersonController playerControler;
    public int danyo;

    private float MIN_SENSITIVITY = 0.5f;
    private float MAX_SENSITIVITY = 2f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            doZoom();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            undoZoom();
        }
    }

    private void undoZoom()
    {
        //Camera/Field of View = Valor inical
        Camera.main.fieldOfView = 60;
        //Ocultamos la vista francotirador
        scopeImage.SetActive(false);
        // Mostramos el arma y la barra de vida
        healthBar.SetActive(true);
        gun.SetActive(true);
        // Recuperamos la velocidad del Player
        playerControler.m_MouseLook.XSensitivity = MAX_SENSITIVITY;
        playerControler.m_MouseLook.YSensitivity = MAX_SENSITIVITY;
    }

    private void doZoom()
    {
        // Camera/Field of View = 20
        Camera.main.fieldOfView = 20; 
        // Tenemos la cámara principal
        // Mostramos la vista francotirador
        scopeImage.SetActive(true);
        // Ocultamos el arma y la barra de vida
        healthBar.SetActive(false);
        gun.SetActive(false);
        // Reducimos la velocidad del Player
        playerControler.m_MouseLook.XSensitivity = MIN_SENSITIVITY;
        playerControler.m_MouseLook.YSensitivity = MIN_SENSITIVITY;
    }

    public override void Shoot()
    {
        RaycastHit hit;
        base.Shoot();
        //Lanzamos el rayo desde el punto en el que está la cámara
        // Para ello cogemos el objeto con el tag "MainCamera"
        // De ahí, cogemos la posición y marcamos una dirección
        Vector3 origen = Camera.main.transform.position;
        Vector3 direccion = Camera.main.transform.forward;

        // Lanzamos el raycast
        // "out" indica que la variable "hit", se modificará cuando el Raycast impacto contra algo
        if (Physics.Raycast(origen, direccion, out hit)) 
        {
            // Enra si choca contra algo
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                hit.transform.gameObject.GetComponentInParent<Enemy>().DamageReceived(danyo);
            }
        }
    }
}
