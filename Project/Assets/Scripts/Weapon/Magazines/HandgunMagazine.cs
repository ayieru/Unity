﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunMagazine : Magazine
{
    // Start is called before the first frame update
    void Awake()
    {
        currentAmmoNum = weaponData.ammo[level];
    }

    void Update()
    {

    }
}
