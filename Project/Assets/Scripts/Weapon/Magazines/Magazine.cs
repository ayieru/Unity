using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magazine : MonoBehaviour
{
    public int level;
    [SerializeField]
    public Ammo ammo;

    public WeaponData weaponData;

    public int currentAmmoNum { get; protected set; }

    void Awake()
    {
        
    }
    void Start()
    {
        currentAmmoNum = weaponData.ammo[level];
    }

    void Update()
    {

    }

    public abstract void LoadMagazine();

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
