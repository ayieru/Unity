using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int power;
    public int headpower;

    [SerializeField]
    Player playerScript;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        var p = other.gameObject.GetComponent<IReceiveDamage>();

        if (p != null)
        {
            bool flag = p.ReceiveDamage(power);
            if(flag)
            {
                var tmpScript2 = other.gameObject.GetComponent<IAddPoints>();
                if(tmpScript2 != null)
                {
                    playerScript.AddPoints(tmpScript2.GetPoints());
                }
            }
        }

        Destroy(gameObject);
    }

}
