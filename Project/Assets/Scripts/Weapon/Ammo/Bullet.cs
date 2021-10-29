using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int power;
    public int headpower;

    public Player playerScript;

    void Awake()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
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
        Destroy(this.gameObject);
    }

    public void SetPower(int sPower)
    {
        power = sPower;
    }
}
