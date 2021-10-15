using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunMagazine : Magazine
{
    // Start is called before the first frame update
    void Awake()
    {
        currentAmmoNum = weaponData.ammo[0];
    }

    void Update()
    {
        
    }
    
    public override void LoadMagazine()
    {
        currentAmmoNum = weaponData.ammo[level];
    }
}
