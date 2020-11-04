using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private GameObject[] weapons;
    [SerializeField]
    private int score;
    [SerializeField]
    private bool shield;
    [SerializeField]
    GameObject healthBar;
    [SerializeField]
    private int activeWeapon = 0;
    [SerializeField]
    public Text textChargers;
    [SerializeField]
    private GameObject[] IconWeapons;
    [SerializeField]
    private int activeIconWeapon = 0;
    [SerializeField]
    private Image bloodImage;
    [SerializeField] 
    GameObject panelMenu;

    private static PlayerManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        health = maxHealth;
        ActivarArma(activeWeapon);
    }

    private void Update()
    {
        ChooseWeapon();
        Shoot();
        Recharge();
    }


    public void ChooseWeapon() {
        for (int i = 0; i <= weapons.Length; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                ActivarArma(i - 1);
            }
        }
    }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weapons[activeWeapon].GetComponent<Weapon>().TryShoot();
        }
    }

    public void Recharge() 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapons[activeWeapon].GetComponent<Weapon>().Reload();
        }
    }

    public void Dying()
    {
        panelMenu.SetActive(true);
        GameObject.Find("GameManager").GetComponent<GameManager>().DoGameOver();
    }

    public void DamageReceived(int danno)
    {
        health = health - danno;
        UpdateHealthBarAndBloodCanvas();
        if (health <= 0) { Dying(); }
    }

    private void UpdateHealthBarAndBloodCanvas()
    {
        healthBar.GetComponent<Image>().fillAmount = health / ((float)maxHealth);

        /*Color colorBlood = bloodImage.color;
        colorBlood.a = 1 - (health / ((float)maxHealth));
        bloodImage.color = colorBlood;*/
    }

    // DONE: Desaparece del terreno, se activa en la UI
    // TODO: guardo estado, permite abrir la puerta, realiza sonido y partículas al cogerla
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            GameObject.Find("ImageKey").GetComponent<Image>().color = Color.yellow;
            GameManager.hasKey = true;
        }

        if (other.gameObject.CompareTag("Cargador"))
        {
            int nc = other.gameObject.GetComponentInParent<CargadorGenerico>().numeroCargadores;
            weapons[activeWeapon].GetComponent<Weapon>().AgregarCargadores(nc);
            Destroy(other.gameObject);
        }*/
    }

    
    public void ActivarArma(int idArma)
    {
        for (int i=0; i<weapons.Length; i++) {
            if (i == idArma)
            {
                weapons[i].SetActive(true);
                IconWeapons[i].SetActive(true);
                activeWeapon = i;
                activeIconWeapon = i;

                int chargers = weapons[i].GetComponent<Weapon>().chargers;
                int bullets = weapons[i].GetComponent<Weapon>().ammo;

                textChargers.text = "x" + chargers.ToString();
                //TextAmmo.text = bullets.ToString();
            }
            else {
                weapons[i].SetActive(false);
                IconWeapons[i].SetActive(false);
            } 
        }
    }

    public bool TieneSaludATope() {
        if (health >= maxHealth)
        {
            return true;
        }
        else {
            return false;
        }
    }

    public void RecuperarSalud(int incSalud)
    {
        health += incSalud;
        // Con esto controlamos que la salud no crezca por encima de maxHealth
        health = Mathf.Min(health, maxHealth);
        UpdateHealthBarAndBloodCanvas();
    }
}
