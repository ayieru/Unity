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
    public void SetItem()
    {
        turret.SetActive(true);
    }
}
