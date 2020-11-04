using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation;
        player.GetComponent<FirstPersonController>().enabled = false;
    }

    private void LateUpdate()
    {
        player.GetComponent<FirstPersonController>().enabled = true;
    }
}
