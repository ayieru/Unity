using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var p = other.gameObject.GetComponent<IReceiveDamage>();

        if (p != null)
        {
            p.ReceiveDamage(20);
        }

        Destroy(gameObject);
    }
}
