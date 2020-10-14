using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBGShell : MonoBehaviour
{
    public int danyo = 50;

    private void OnCollisionEnter(Collision collision)
    {
        print("en el collision");
        print(gameObject);
        if (gameObject.CompareTag("Skeleton1"))
        {
            print("Llamando a DamageReceived " + danyo);
            gameObject.GetComponentInParent<Enemies>().DamageReceived(danyo);
        }
        else {
            print("impacta cualquier cosa");
        }
        Destroy(gameObject);
    }
}
