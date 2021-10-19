using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int power;
    public int headpower;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("aaaaa");
    //    var p = other.gameObject.GetComponent<IReceiveDamage>();

    //    if (p != null)
    //    {
    //        p.ReceiveDamage(power);
    //    }

    //    Destroy(gameObject);
    //}


    void OnCollisionEnter(UnityEngine.Collision other)
    {
        Debug.Log("aaaaa");
        var p = other.gameObject.GetComponent<IReceiveDamage>();

        if (p != null)
        {
            p.ReceiveDamage(power);
        }

        Destroy(gameObject);
    }
}
