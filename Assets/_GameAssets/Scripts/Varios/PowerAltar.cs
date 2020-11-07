using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAltar : MonoBehaviour
{
    public int healthReduction;
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
            StartCoroutine("ReduceHealth");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StopAllCoroutines();
        }
    }

    IEnumerator ReduceHealth()
    {
        print("entró en ReduceHealth");
        while (pm.HealthAtMin())
        {
            pm.HealthReduction(healthReduction);
            yield return new WaitForSeconds(delayAcumulation);
        }
    }
}
