using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    void SetWeapon(GameObject gameObject, int level)
    {
        weapon[currentWeaponNum].GOWeapon = Instantiate(gameObject, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].weaponScript = weapon[currentWeaponNum].GOWeapon.GetComponent<Weapon>();
        weapon[currentWeaponNum].weaponScript.SetLevel(level);
    }
}
