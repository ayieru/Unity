using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour , IReceiveDamage
{
    GameObject GOPlayerCamera;
    // 繝｢繝ｼ繝・
    enum Mode
    {
        Weapon,
        Item,
        Max
    }

    Mode mode = Mode.Weapon;

    public WeaponData handgun;
    public WeaponData shotgun;
    public WeaponData assaltLifle;
    public WeaponData roketLancher;

    // 豁ｦ蝎ｨ
    private const int weaponCount = 2;
    public class WeaponInfo
    {
        public GameObject GO;
        public Weapon script;
    };
    public List<WeaponInfo> weapon { get; private set; } = new List<WeaponInfo>();
    private int currentWeaponNum = 0;

    // 繧｢繧､繝・Β
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

    // 菴灘鴨
    public float maxHp { get; private set; }
    public float currentHp { get; private set; }

    //Item item;


    void Start()
    {
        Vector3 position;
        WeaponInfo tmpWeapon = new WeaponInfo();
        ItemInfo tmpItem = new ItemInfo();

        position = transform.GetChild(0).position + handgun.weapon.transform.position;
        GameObject tmpGO =  Instantiate(handgun.weapon, position, handgun.weapon.transform.rotation, transform.GetChild(0));
        weapon.Add(new WeaponInfo{
            GO = tmpGO,
            script = tmpGO.GetComponent<Weapon>()
        });
        Debug.Log(weapon[0].GO);

        position = transform.GetChild(0).position + shotgun.weapon.transform.position;
        tmpGO =  Instantiate(shotgun.weapon, position, shotgun.weapon.transform.rotation, transform.GetChild(0));
        weapon.Add(new WeaponInfo{
            GO = tmpGO,
            script = tmpGO.GetComponent<Weapon>()
        });

        weapon[1].GO.SetActive(false);

        // 繧｢繧､繝・Β
        position = transform.GetChild(0).position + barricade.transform.position;
        tmpGO =  Instantiate(barricade, position, transform.rotation, this.transform);
        item.Add(new ItemInfo{
            GO = tmpGO,
            script = tmpGO.GetComponent<Item>()
        });

        position = this.transform.position + board.transform.position;
        tmpGO =  Instantiate(board, position, transform.rotation, this.transform);
        item.Add(new ItemInfo{
            GO = tmpGO,
            script = tmpGO.GetComponent<Item>()
        });

        position = this.transform.position + landmine.transform.position;
        tmpGO =  Instantiate(landmine, position, transform.rotation, this.transform);
        item.Add(new ItemInfo{
            GO = tmpGO,
            script = tmpGO.GetComponent<Item>()
        });

        position = this.transform.position + turret.transform.position;
        tmpGO =  Instantiate(turret, position, transform.rotation, this.transform);
        item.Add(new ItemInfo{
            GO = tmpGO,
            script = tmpGO.GetComponent<Item>()
        });

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
        // 蛻・ｊ譖ｿ縺・
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
