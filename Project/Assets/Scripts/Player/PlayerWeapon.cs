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
        Vector3 position;
        GameObject tmpGO;

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
}
