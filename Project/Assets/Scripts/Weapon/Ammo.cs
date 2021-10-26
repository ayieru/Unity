using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int power;
    public int headpower;

    [SerializeField]
    GameObject playerScript;

    void Awake()
    {
        playerScript = GameObject.Find("Player");
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
                    playerScript.GetComponent<Player>().AddPoints(tmpScript2.GetPoints());
                }
            }
        }

        Destroy(gameObject);
    }

    public void SetPower(int sPower)
    {
        power = sPower;
    }
}
