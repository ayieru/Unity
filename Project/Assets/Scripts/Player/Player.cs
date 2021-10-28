using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour, IPlayerReceiveDamage
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
    // Data(ScriptableObject)
    public WeaponData DHandgun;
    public WeaponData DShotgun;
    public WeaponData DAssaultRifle;
    public WeaponData DRoketLancher;
    public ItemData DItem;

    // 武器
    private const int weaponCount = 2;
    public enum EWeapon
    {
        Handgun,
        Shotgun,
        AssaultRifle,
        RocketLauncher,
        Max
    }
    public int[] haveWeaponNum = new int[(int)EWeapon.Max];

    public class WeaponInfo
    {
        public GameObject GO;
        public Weapon script;
    };
    public List<WeaponInfo> weapon { get; private set; } = new List<WeaponInfo>();
    public int currentWeaponNum { get; private set; } = 0;

    // アイテム
    public enum EItem
    {
        Barricade,
        Board,
        Landmine,
        Turret,
        Max
    }
    public class ItemInfo
    {
        public GameObject GO = null;
        public Item script;
        public int maxNum;
        public int currentNum;
    }

    public EItem currentItemAttr { get; private set; } = EItem.Barricade;
    List<ItemInfo> item = new List<ItemInfo>();

    // 体力
    public float maxHp { get; private set; }
    public float currentHp { get; private set; }
    //public float heal = 10;

    // ポイント
    public int points { get; private set; } = 0;

    // ダメージを受ける状態フラグ
    bool receiveDamageFrag = true;
    [SerializeField] float invincibleTime = 5.0f;

    // Get関数
    public int GetWeaponAmmoNum()
    {
        return weapon[currentWeaponNum].script.magazine.currentAmmoNum;
    }
    public int GetItemCurrentNum(EItem itemAttr)
    {
        return item[(int)itemAttr].currentNum;
    }
    public int GetItemMaxNum(EItem itemAttr)
    {
        return item[(int)itemAttr].maxNum;
    }
    public int GetItemCurrentNum()
    {
        return item[(int)currentItemAttr].currentNum;
    }

    void Start()
    {
        for(int i = 0; i < haveWeaponNum.Length; i++)
        {
            haveWeaponNum[i] = 0;
        }
        WeaponInit();
        ItemInit();

        maxHp = 100;
        currentHp = maxHp;

        MovementStart();
        CameraStart();
    }

    //
    int ZeroClampNum(int num, bool increace)
    {
        if(increace){
            num++;
        }
        else{
            num--;
        }
        return Mathf.Clamp(num, 0, sizeof(int));
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
                if (Input.GetMouseButton(0))
                {
                    Shoot();
                }
                else if(Input.GetMouseButtonUp(0))
                {
                    ShootEnd();
                }
                if(Input.GetKeyDown(KeyCode.R) || weapon[currentWeaponNum].script.magazine.currentAmmoNum == 0)
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

    public void ReceiveDamage(int damage)
    {
        if(receiveDamageFrag)
        {
            receiveDamageFrag = false;
            currentHp -= damage;
            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
            Invoke("ReceiveDamageFragOn", invincibleTime);
        }
    }
    void ReceiveDamageFragOn()
    {
        receiveDamageFrag = true;
    }

    void Shoot()
    {
        weapon[currentWeaponNum].script.Shoot();
    }
    void ShootEnd()
    {
        weapon[currentWeaponNum].script.ShootEnd();
    }

    void Reload()
    {
        weapon[currentWeaponNum].script.Reload();
    }

    void Install()
    {
        item[(int)currentItemAttr].script.Install();
        item[(int)currentItemAttr].currentNum = ZeroClampNum(item[(int)currentItemAttr].currentNum, false);
        int tmpNum = item[(int)currentItemAttr].currentNum;
        ItemInstantiate(currentItemAttr);
        item[(int)currentItemAttr].currentNum = tmpNum;
        if(item[(int)currentItemAttr].currentNum <= 0)
        {
            currentItemAttr++;
            if(currentItemAttr >= EItem.Max)
            {
                currentItemAttr = EItem.Barricade;
            }
            if(item[(int)currentItemAttr].currentNum > 0)
            {
                item[(int)currentItemAttr].GO.SetActive(true);
            }
        }
        else
        {
            if(item[(int)currentItemAttr].currentNum > 0)
            {
                item[(int)currentItemAttr].GO.SetActive(true);
            }
        }
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
        item[(int)currentItemAttr].GO.SetActive(false);
        currentItemAttr++;
        if(currentItemAttr >= EItem.Max)
        {
            currentItemAttr = EItem.Barricade;
        }
        item[(int)currentItemAttr].GO.SetActive(true);
    }


    void SwitchItemsAndWeapon()
    {
        switch(mode)
        {
            case Mode.Weapon:
                weapon[currentWeaponNum].GO.SetActive(false);
                break;
            case Mode.Item:
                item[(int)currentItemAttr].GO.SetActive(false);
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
                item[(int)currentItemAttr].GO.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public void HealHp()
    {
        currentHp = maxHp;
    }
}
