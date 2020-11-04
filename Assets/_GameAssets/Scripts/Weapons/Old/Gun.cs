using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Gun : MonoBehaviour
{

    public GameObject proyectil;
    public Transform posInicio;
    public float fuerza;
    [SerializeField]
    private AudioClip shootSound;

    // Capturamos la imagen del scope
    public GameObject scopeImage;
    // Capturamos la barra de salud del player para ocultarla
    public GameObject healthBar;
    // capturamos el objeto arma
    public GameObject gun;
    // modificamos la velocidad del Player
    public FirstPersonController playerControler;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //GetComponent<AudioSource>().PlayOneShot(shootSound);
            GameObject bala = Instantiate(proyectil, posInicio.position, posInicio.rotation);
            bala.GetComponent<Rigidbody>().AddForce(posInicio.forward * fuerza);
        }   
        if (Input.GetButtonDown("Fire2"))
        {   
            // Camera/Field of View = 20
            Camera.main.fieldOfView = 20; //Tenemos la cámara principal
            // Mostramos la vista francotirador
            scopeImage.SetActive(true);
            // Ocultamos el arma y la barra de vida
            healthBar.SetActive(false);
            gun.SetActive(false);
            // Reducimos la velocidad del Player
            playerControler.m_MouseLook.XSensitivity = 0.5f;
            playerControler.m_MouseLook.YSensitivity = 0.5f;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            //Camera/Field of View = Valor inical
            Camera.main.fieldOfView = 60;
            //Ocultamos la vista francotirador
            scopeImage.SetActive(false);
            // Mostramos el arma y la barra de vida
            healthBar.SetActive(true);
            gun.SetActive(true);
            // Recuperamos la velocidad del Player
            playerControler.m_MouseLook.XSensitivity = 2f;
            playerControler.m_MouseLook.YSensitivity = 2f;
        }
    }
}
