using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    int level;
    float damage;

    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject GO_firingPoint;

    Magazine magazine;
    Ammo ammo;

    public abstract void Reload();
    public abstract void Shoot();

}
