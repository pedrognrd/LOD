using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSkeletons1 : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabEnemy;
    [SerializeField]
    private float timeBetweenInstances;
    [SerializeField]
    private int maxEnemies;

    private int enemiesCreated = 0;
    private const float MIN_ANGLE = -45;
    private const float MAX_ANGLE = 45;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSkeletons",0,timeBetweenInstances);
    }

    void SpawnSkeletons() {
        Vector3 rotation = new Vector3(0, Random.Range(MIN_ANGLE,MAX_ANGLE),0);
        Instantiate(prefabEnemy, transform.position, Quaternion.Euler(rotation));
        enemiesCreated++;
        if (enemiesCreated == maxEnemies) {
            CancelInvoke();
        }
    }
}
