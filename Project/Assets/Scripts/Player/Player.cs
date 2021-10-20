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

    public WeaponData handgun;
    public WeaponData shotgun;
    public WeaponData assaultRifle;
    public WeaponData roketLancher;

    // 武器
    private const int weaponCount = 2;
    public class WeaponInfo
    {
        public GameObject GO;
        public Weapon script;
    };
    public List<WeaponInfo> weapon { get; private set; } = new List<WeaponInfo>();
    private int currentWeaponNum = 0;

    // アイテム
    public class ItemInfo
    {
        public GameObject GO;
        public Item script;
    };
    const int itemCount = 4;
    int currentItemNum = 0;
    List<ItemInfo> item = new List<ItemInfo>();
    public GameObject barricade;
    public GameObject board;
    public GameObject landmine;
    public GameObject turret;

    // 体力
    public float maxHp { get; private set; }
    public float currentHp { get; private set; }

    // ポイント
    int points = 0;

    void Start()
    {
        WeaponInit();
        ItemInit();

        maxHp = 100;
        currentHp = maxHp;

        MovementStart();
        CameraStart();
    }

    void Update()
    {
        MovementUpdate();
        CameraUpdate();
        ReloadUpdate();

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
                if (Input.GetMouseButton(0))
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

    public bool ReceiveDamage(int Pdamage)
    {
        currentHp -= Pdamage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        return true;
    }

    void Shoot()
    {
        weapon[currentWeaponNum].script.Shoot();
    }

    void Reload()
    {
        reloadFlag = true;
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

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public void Handgun()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(handgun.weapon, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[0].GO.GetComponent<Weapon>();
    }

    public void Shotgun()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(shotgun.weapon, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
    }
    public void AssaultRifle()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(assaultRifle.weapon, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
    }
    public void RoketLancher()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(roketLancher.weapon, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
    }
}
