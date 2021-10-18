using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    void SetWeapon(GameObject gameObject, int level)
    {
        weapon[currentWeaponNum].GO = Instantiate(gameObject, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
        weapon[currentWeaponNum].script.SetLevel(level);
    }
}
