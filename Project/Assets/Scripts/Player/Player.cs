using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour , IReceiveDamage
{
    GameObject GOPlayerCamera;

    // 武器
    private const int weaponCount = 2;
    public struct weaponInfo
    {
        public GameObject GOWeapon;
        public Weapon weaponScript;
    };
    public weaponInfo[] weapon { get; private set; } = new weaponInfo[weaponCount];

    private int currentWeaponNum = 0;
    // 一時的
    public GameObject handgun;

    // 体力
    public float maxHp { get; private set; }
    public float currentHp { get; private set; }

    //Item item;


    void Start()
    {
        weapon[0].GOWeapon = Instantiate(handgun, transform.position, transform.rotation, transform.GetChild(0));
        weapon[1].GOWeapon = Instantiate(handgun, transform.position, transform.rotation, transform.GetChild(0));
        weapon[0].weaponScript = weapon[0].GOWeapon.GetComponent<Weapon>();
        weapon[1].weaponScript = weapon[0].GOWeapon.GetComponent<Weapon>();

        weapon[1].GOWeapon.SetActive(false);

        maxHp = 100;
        currentHp = maxHp;

        MovementStart();
        CameraStart();
    }

    void Update()
    {
        MovementUpdate();
        CameraUpdate();

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void FixedUpdate()
    {
        MovementFixedUpdate();
    }

    public void ReceiveDamage(int Pdamage)
    {
        currentHp -= Pdamage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
    }

    void Shoot()
    {
        weapon[currentWeaponNum].weaponScript.Shoot();
    }

    void Reload()
    {
        weapon[currentWeaponNum].weaponScript.Reload();
    }

    void WeaponSwitch()
    {
        weapon[currentWeaponNum].GOWeapon.SetActive(false);
        currentWeaponNum++;
        weapon[currentWeaponNum].GOWeapon.SetActive(true);
    }

}
