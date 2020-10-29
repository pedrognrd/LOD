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

     // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Attack() { }

    public abstract void Move();

    public void Detect() { }

    public void DamageDone() { }

    protected void Blooding(Vector3 bloodPosition)
    {
        GameObject hit = Instantiate(prefabBlood, bloodPosition, transform.rotation);
    }

    public void DamageReceived(int danno)
    {
        health = health - danno;
        healthSlider.value = healthSlider.maxValue - health;

        if (health <= 0)
        {
            Dying();
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

    protected void Dying()
    {
        GetComponent<AudioSource>().PlayOneShot(painSound);
        GameObject explosion = Instantiate(prefabExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
