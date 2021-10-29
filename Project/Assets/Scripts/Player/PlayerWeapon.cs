using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    void WeaponInit()
    {
        WeaponInstantite(DHandgun, EWeapon.Handgun);
        WeaponInstantite(DShotgun, EWeapon.Shotgun);

        weapon[1].GO.SetActive(false);
    }

    void ItemInit()
    {
        for(int i = 0; i < 4; i++)
        {
            item.Add(new ItemInfo());
        }

        ItemInstantiate(EItem.Barricade);
        ItemInstantiate(EItem.Board);
        ItemInstantiate(EItem.Landmine);
        ItemInstantiate(EItem.Turret);
    }

    void ItemInstantiate(EItem itemAttr)
    {
        GameObject tmpGO;

        Debug.Log(DItem.item[(int)itemAttr].transform.position);
        tmpGO = Instantiate(DItem.item[(int)itemAttr], this.transform, false);
        item[(int)itemAttr].GO = tmpGO;
        item[(int)itemAttr].script = tmpGO.GetComponent<Item>();
        item[(int)itemAttr].maxNum = DItem.max[(int)itemAttr];
        item[(int)itemAttr].currentNum = 2;

        item[(int)itemAttr].GO.SetActive(false);
    }

    void WeaponInstantite(WeaponData DWeapon, EWeapon weaponName)
    {
        GameObject tmpGO;

        tmpGO =  Instantiate(DWeapon.weapon, transform.GetChild(0), false);
        this.weapon.Add(new WeaponInfo{
            GO = tmpGO,
            script = tmpGO.GetComponent<Weapon>()
        });
        haveWeaponNum[(int)weaponName] += 1;
    }
    
    public void AddItem(EItem itemAttr)
    {
        item[(int)itemAttr].currentNum += 1;
        if(item[(int)itemAttr].currentNum > item[(int)itemAttr].maxNum)
        {
            item[(int)itemAttr].currentNum = item[(int)itemAttr].maxNum;
        }
    }

    public void BuyBarricade()
    {
        if(points >= DItem.cost[(int)EItem.Barricade])
        {
            AddItem(EItem.Barricade);
            points -= DItem.cost[(int)EItem.Barricade];
        }
    }
    public void BuyBoard()
    {
        if(points >= DItem.cost[(int)EItem.Board])
        {
            AddItem(EItem.Board);
            points -= DItem.cost[(int)EItem.Board];
        }
    }
    public void BuyLandmine()
    {
        if(points >= DItem.cost[(int)EItem.Landmine])
        {
            AddItem(EItem.Landmine);
            points -= DItem.cost[(int)EItem.Landmine];
        }
    }

    public void BuyTurret()
    {
        if(points >= DItem.cost[(int)EItem.Turret])
        {
            AddItem(EItem.Turret);
            points -= DItem.cost[(int)EItem.Turret];
        }
    }
    public void BuyPortion()
    {
        if(points >= DItem.cost[4])
        {
            HealHp();
            points -= DItem.cost[4];
        }
    }
    
    public void BuyHandgun()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(DHandgun.weapon, transform.GetChild(0), false);
        weapon[currentWeaponNum].script = weapon[0].GO.GetComponent<Weapon>();
        points -= DHandgun.cost[0];
    }
    public void BuyShotgun()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(DShotgun.weapon, transform.GetChild(0), false);
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
        points -= DShotgun.cost[0];
    }
    public void BuyAssaultRifle()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(DAssaultRifle.weapon, transform.GetChild(0), false);
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
        points -= DAssaultRifle.cost[0];
    }
    public void BuyRoketLancher()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(DRoketLancher.weapon, transform.GetChild(0), false);
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
        points -= DRoketLancher.cost[0];
    }

    public void UpdateHandgun(int level)
    {
        if(level <= DHandgun.level.Length)
        {
            if(points >= DHandgun.cost[level - 1])
            {
                weapon[currentWeaponNum].script.UPLevel();
                points -= DHandgun.cost[level - 1];
            }
        }
    }
    public void UpdateShotgun(int level)
    {
        if(level <= DHandgun.level.Length)
        {
            if(points >= DHandgun.cost[level - 1])
            {
                weapon[currentWeaponNum].script.UPLevel();
                points -= DHandgun.cost[level - 1];
            }
        }
    }
    public void UpdateAssaultRifle(int level)
    {
        if(level <= DHandgun.level.Length)
        {
            if(points >= DHandgun.cost[level - 1])
            {
                weapon[currentWeaponNum].script.UPLevel();
                points -= DHandgun.cost[level - 1];
            }
        }
    }
    public void UpdateRoketLancher(int level)
    {
        if(level <= DHandgun.level.Length)
        {
            if(points >= DHandgun.cost[level - 1])
            {
                weapon[currentWeaponNum].script.UPLevel();
                points -= DHandgun.cost[level - 1];
            }
        }
    }

}
