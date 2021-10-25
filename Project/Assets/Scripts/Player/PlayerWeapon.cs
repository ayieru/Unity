using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    void WeaponInit()
    {
        WeaponInstantite(DAssaultRifle);
        WeaponInstantite(DShotgun);

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

    void WeaponInstantite(WeaponData DWeapon)
    {
        GameObject tmpGO;

        tmpGO =  Instantiate(DWeapon.weapon, transform.GetChild(0), false);
        this.weapon.Add(new WeaponInfo{
            GO = tmpGO,
            script = tmpGO.GetComponent<Weapon>()
        });
    }

    public void BuyItem(EItem itemAttr)
    {
        item[(int)itemAttr].currentNum++;
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
}
