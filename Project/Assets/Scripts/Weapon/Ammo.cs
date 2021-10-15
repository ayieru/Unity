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

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<EnemyAI>().ReceiveDamage(power);
    }

}
