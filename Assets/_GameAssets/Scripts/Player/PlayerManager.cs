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
    private int maxHealth;
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject[] weapons;
    [SerializeField]
    private int score;
    [SerializeField]
    private bool shield;
    [SerializeField]
    private bool key;
    [SerializeField]
    GameObject healthBar;
    [SerializeField]
    private int activeWeapon = 0;

    private void Awake()
    {
        health = maxHealth;
    }
    // Start is called before the first frame update
    private void Update()
    {
        //Weapon selection
        for (int i = 1; i <= weapons.Length; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                ActivateWeapon(i - 1);

            }
        }

        //Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            weapons[activeWeapon].GetComponent<Weapon>().TryShoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapons[activeWeapon].GetComponent<Weapon>().Reload();
        }
    }

    public void ActivateWeapon(int idWeapon)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == idWeapon)
            {
                weapons[i].SetActive(true);
                activeWeapon = i;
            }
            else
            {
                weapons[i].SetActive(false);
            }

        }
    }
}
