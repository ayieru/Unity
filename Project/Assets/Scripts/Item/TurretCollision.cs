using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollision : MonoBehaviour
{
    public GameObject turret;

    private void Start()
    {
        turret.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            turret.SetActive(true);
        }
    }
}
