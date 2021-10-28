using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magazine : MonoBehaviour
{
    public int level;
    [SerializeField]
    public Bullet bullet;
    public Shell shell;

    public WeaponData weaponData;

    public int currentAmmoNum { get; protected set; }

    void Start()
    {

    }

    void Update()
    {

    }

    public void LoadMagazine()
    {
        currentAmmoNum = weaponData.ammo[level];
    }

    public bool LoadGun()
    {
        if(currentAmmoNum > 0){
            currentAmmoNum -= 1;
            return true;
        }
        else
        {
            return false;
        }
    }
}
