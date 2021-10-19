using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour , IReceiveDamage
{
    GameObject GOPlayerCamera;
    // モード
    enum Mode
    {
        Weapon,
        Item,
        Max
    }

    Mode mode = Mode.Weapon;

    public WeaponData h;
    public WeaponData s;
    public WeaponData a;
    public WeaponData r;

    // 武器
    private const int weaponCount = 4;
    public struct WeaponInfo
    {
        public GameObject GO;
        public Weapon script;
    };
    public WeaponInfo[] weapon { get; private set; } = new WeaponInfo[weaponCount];
    private int currentWeaponNum = 0;

    public GameObject handgun;

    // アイテム
    public struct ItemInfo
    {
        public GameObject GO;
        public Item script;
    };
    const int itemCount = 4;
    int currentItemNum = 0;
    ItemInfo[] item = new ItemInfo[itemCount];
    public GameObject barricade;
    public GameObject board;
    public GameObject landmine;
    public GameObject turret;

    // 体力
    public float maxHp { get; private set; }
    public float currentHp { get; private set; }

    //Item item;


    void Start()
    {
        Vector3 position = transform.GetChild(0).position + handgun.transform.position;
        weapon[0].GO = Instantiate(h.weapon, position, h.weapon.transform.rotation, transform.GetChild(0));
        weapon[1].GO = Instantiate(s.weapon, position, s.weapon.transform.rotation, transform.GetChild(0));
        weapon[2].GO = Instantiate(a.weapon, position, a.weapon.transform.rotation, transform.GetChild(0));
        weapon[3].GO = Instantiate(r.weapon, position, r.weapon.transform.rotation, transform.GetChild(0));

        weapon[0].script = weapon[0].GO.GetComponent<Weapon>();
        weapon[1].script = weapon[1].GO.GetComponent<Weapon>();
        weapon[2].script = weapon[2].GO.GetComponent<Weapon>();
        weapon[3].script = weapon[3].GO.GetComponent<Weapon>();

        weapon[1].GO.SetActive(false);
        weapon[2].GO.SetActive(false);
        weapon[3].GO.SetActive(false);

        position = this.transform.position + barricade.transform.position;
        item[0].GO = Instantiate(barricade, position, transform.rotation, this.transform);
        position = this.transform.position + board.transform.position;
        item[1].GO = Instantiate(board, position, transform.rotation, this.transform);
        position = this.transform.position + landmine.transform.position;
        item[2].GO = Instantiate(landmine, position, transform.rotation, this.transform);
        position = this.transform.position + turret.transform.position;
        item[3].GO = Instantiate(turret, position, transform.rotation, this.transform);
        item[0].script = item[0].GO.GetComponent<Item>();
        item[1].script = item[1].GO.GetComponent<Item>();
        item[2].script = item[2].GO.GetComponent<Item>();
        item[3].script = item[3].GO.GetComponent<Item>();
        item[0].GO.SetActive(false);
        item[1].GO.SetActive(false);
        item[2].GO.SetActive(false);
        item[3].GO.SetActive(false);


        maxHp = 100;
        currentHp = maxHp;

        MovementStart();
        CameraStart();
    }

    void Update()
    {
        MovementUpdate();
        CameraUpdate();

        if(Input.GetKeyDown(KeyCode.M))
        {
            SwitchItemsAndWeapon();
            Debug.Log(mode);
        }
        // 切り替え
        if(0 < Input.GetAxis("Mouse ScrollWheel"))
        {
            switch (mode)
            {
                case Mode.Weapon:
                    SwitchWeapon();
                    break;
                case Mode.Item:
                    SwitchItem();
                    break;
                default:
                    break;
            }
        }

        switch(mode)
        {
            case Mode.Weapon:
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }
                if(Input.GetKeyDown(KeyCode.R))
                {
                    Reload();
                }
                break;
            case Mode.Item:
                if (Input.GetMouseButtonDown(0))
                {
                    Install();
                }
                break;
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
        weapon[currentWeaponNum].script.Shoot();
    }

    void Reload()
    {
        weapon[currentWeaponNum].script.Reload();
    }

    void Install()
    {
        item[currentItemNum].script.Install();
        item[currentItemNum].GO = null;
        item[currentItemNum].script = null;
        currentItemNum++;
        if(currentItemNum >= itemCount)
        {
            currentItemNum = 0;
        }
        item[currentItemNum].GO.SetActive(true);
    }

    void SwitchWeapon()
    {
        weapon[currentWeaponNum].GO.SetActive(false);
        currentWeaponNum++;
        if(currentWeaponNum >= weaponCount)
        {
            currentWeaponNum = 0;
        }
        weapon[currentWeaponNum].GO.SetActive(true);
    }

    void SwitchItem()
    {
        item[currentItemNum].GO.SetActive(false);
        currentItemNum++;
        if(currentItemNum >= itemCount)
        {
            currentItemNum = 0;
        }
        item[currentItemNum].GO.SetActive(true);
    }


    void SwitchItemsAndWeapon()
    {
        switch(mode)
        {
            case Mode.Weapon:
                weapon[currentWeaponNum].GO.SetActive(false);
                break;
            case Mode.Item:
                item[currentItemNum].GO.SetActive(false);
                break;
            default:
                break;
        }
        mode++;
        if(mode == Mode.Max)
        {
            mode = Mode.Weapon;
        }
        switch(mode)
        {
            case Mode.Weapon:
                weapon[currentWeaponNum].GO.SetActive(true);
                break;
            case Mode.Item:
                item[currentItemNum].GO.SetActive(true);
                break;
            default:
                break;
        }
    }

    //public void H()
    //{
    //    Destroy(weapon[0].GOWeapon);
    //    Destroy(weapon[0].weaponScript);
    //    weapon[0].GOWeapon = Instantiate(h.weapon, transform.position, transform.rotation, transform.GetChild(0));
    //    weapon[0].weaponScript = weapon[0].GOWeapon.GetComponent<Weapon>();
    //}

    //public void S()
    //{
    //    Destroy(weapon[0].GOWeapon);
    //    Destroy(weapon[0].weaponScript);
    //    weapon[0].GOWeapon = Instantiate(s.weapon, transform.position, transform.rotation, transform.GetChild(0));
    //    weapon[0].weaponScript = weapon[0].GOWeapon.GetComponent<Weapon>();
    //}
    //public void A()
    //{
    //    Destroy(weapon[0].GOWeapon);
    //    Destroy(weapon[0].weaponScript);
    //    weapon[0].GOWeapon = Instantiate(a.weapon, transform.position, transform.rotation, transform.GetChild(0));
    //    weapon[0].weaponScript = weapon[0].GOWeapon.GetComponent<Weapon>();
    //}
    //public void R()
    //{
    //    Destroy(weapon[0].GOWeapon);
    //    Destroy(weapon[0].weaponScript);
    //    weapon[0].GOWeapon = Instantiate(r.weapon, transform.position, transform.rotation, transform.GetChild(0));
    //    weapon[0].weaponScript = weapon[0].GOWeapon.GetComponent<Weapon>();
    //}
}
