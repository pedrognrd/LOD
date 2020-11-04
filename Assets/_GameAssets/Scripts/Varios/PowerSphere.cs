using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSphere : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
}
