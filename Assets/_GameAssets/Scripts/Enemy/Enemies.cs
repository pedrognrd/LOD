using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemies : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    protected int damageDone;
    [SerializeField]
    protected float speed;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private GameObject prefabHit;
    [SerializeField]
    private GameObject prefabExplosion;
    [SerializeField]
    private AudioClip explosionSound;
    [SerializeField]
    private AudioClip painSound;
    [SerializeField]
    private int points;
    [SerializeField]
    private GameObject prefabBlood;
    [SerializeField]
    private GameObject gameManager;

    protected GameObject player;
    protected bool autodestruccion = false;

    protected void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        //float distance = DistanceToPlayer();
       /*if (distance <= attackDistance)
        {
            Attack();
        }*/
    }

    public abstract void Attack();

    protected void Blooding(Vector3 bloodPosition)
    {
        GameObject hit = Instantiate(prefabBlood, bloodPosition, transform.rotation);
    }

    /*protected float DistanceToPlayer()
    {
        //print("UPDATE DE PLAYER");
        //Vector3 vDistance = player.transform.position - transform.position;
        //float distance = vDistance.magnitude;
        //float distance = 2;
        //return distance;
    }*/

    public void DamageReceived(int danno)
    {
        health = health - danno;
        healthSlider.value = healthSlider.maxValue - health;

        if (health <= 0)
        {
            Dying(autodestruccion = true);
        }
    }

    public void DamageReceived(int danno, Vector3 position)
    {
        health = health - danno;
        healthSlider.value = healthSlider.maxValue - health;

        if (health > 0)
        {
            Blooding(position);
        }
    }

    public void Detect() { }

    /*protected void Dying()
    {
        GetComponent<AudioSource>().PlayOneShot(painSound);
        GameObject explosion = Instantiate(prefabExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }*/

    protected void Dying(bool autodestruccion)
    {
        gameManager.GetComponent<AudioSource>().PlayOneShot(painSound);
        GameObject explosion = Instantiate(prefabExplosion, transform.position, transform.rotation);
        //explosion.GetComponent<AudioSource>().clip = explosionSound;
        //explosion.GetComponent<AudioSource>().Play();
        Destroy(gameObject);

        if (autodestruccion)
        {
            gameManager = GameObject.Find("GameManager");
            //gameManager.GetComponent<GameManager>().IncrementarPuntuacion(points);
        }

    }

    public abstract void Move();
}
