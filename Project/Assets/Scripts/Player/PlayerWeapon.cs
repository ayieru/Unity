using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    void WeaponInit()
    {
        Vector3 position;
        GameObject tmpGO;

        position = transform.GetChild(0).position + handgun.weapon.transform.position;
        tmpGO =  Instantiate(handgun.weapon, position, handgun.weapon.transform.rotation, transform.GetChild(0));
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

    bool reloadFlag = false;
    float reloadElapsedTime = 0;
    float reloadTime = 1;

    void ReloadUpdate()
    {
        if(reloadFlag == true){
            reloadElapsedTime += Time.deltaTime;
            if(reloadElapsedTime > reloadTime)
            {
                reloadElapsedTime = 0;
                reloadFlag = false;

                weapon[currentWeaponNum].script.Reload();
            }
        }
    }

    void ItemInstantiate(EItem itemAttr)
    {
        //Vector3 position;
        GameObject tmpGO;

        //position = this.transform.position + itemData.item[(int)itemAttr].transform.position;
        Debug.Log(itemData.item[(int)itemAttr].transform.position);
        tmpGO = Instantiate(itemData.item[(int)itemAttr], this.transform, false);//.position, transform.rotation, this.transform);
        item[(int)itemAttr].GO = tmpGO;
        item[(int)itemAttr].script = tmpGO.GetComponent<Item>();
        item[(int)itemAttr].maxNum = itemData.max[(int)itemAttr];
        item[(int)itemAttr].currentNum = 2;

        item[(int)itemAttr].GO.SetActive(false);
    }
    public void BuyHandgun()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(handgun.weapon, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[0].GO.GetComponent<Weapon>();
    }
    public void BuyShotgun()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(shotgun.weapon, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
    }
    public void BuyAssaultRifle()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(assaultRifle.weapon, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
    }
    public void BuyRoketLancher()
    {
        Destroy(weapon[currentWeaponNum].GO);
        weapon[currentWeaponNum].GO = Instantiate(roketLancher.weapon, transform.position, transform.rotation, transform.GetChild(0));
        weapon[currentWeaponNum].script = weapon[currentWeaponNum].GO.GetComponent<Weapon>();
    }
}
