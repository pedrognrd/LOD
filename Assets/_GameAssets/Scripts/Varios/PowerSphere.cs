using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSphere : MonoBehaviour
{
    public int healthHealing;
    public float delayAcumulation;
    private GameObject player;
    private PlayerManager pm;
    private void Start()
    {
        player = GameObject.Find("Player");
        pm = player.GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            print("entra player");
            //Comienza la carga
            StartCoroutine("CargarSalud");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            print("sale player");
            //Detiene la carga
            StopAllCoroutines();
        }
    }

    IEnumerator CargarSalud()
    {
        //while(true)
        while (!pm.HealthAtMax())
        {
            pm.HealthRecovery(healthHealing);
            yield return new WaitForSeconds(delayAcumulation);
            //yield return null;//Sin demora
        }
    }
}
