using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    new void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        if(!shootFlag){
            shootElapsedTime += Time.deltaTime;
            if(shootElapsedTime > shootRate)
            {
                shootElapsedTime = 0;
                shootFlag = true;
            }
        }

        ReloadUpdate();
    }

    public override void Shoot()
    {
        if(shootFlag && !reloadFrag)
        {
            if(magazine.LoadGun())
            {
                audioSource.PlayOneShot(shot);
                // 上で取得した場所に、"bullet"のPrefabを出現させる
                Reload();
                // 出現させたボールのforward(z軸方向)
                Vector3 direction = GetFPForward();
                // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
                magazine.bullet.gameObject.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);
                magazine.bullet.GetComponent<Bullet>().SetPower((int)power);
                magazine.bullet.gameObject.GetComponent<Rigidbody>().AddForce(direction * 0.01f, ForceMode.Impulse);
                // 出現させたボールの名前を"bullet"に変更
                magazine.bullet.gameObject.GetComponent<Bullet>().playerScript = playerScript;
                magazine.bullet.gameObject.name = magazine.bullet.gameObject.name;
                shootFlag = false;
            }
        }
    }

    public override void ReloadUpdate()
    {
        if(reloadFrag == true){
            reloadElapsedTime += Time.deltaTime;
            if(reloadElapsedTime > reloadTime)
            {
                audioSource.PlayOneShot(reload);
                reloadElapsedTime = 0;
                reloadFrag = false;
                Instantiate(magazine.bullet.gameObject, GetFPPosition(), magazine.bullet.transform.rotation);
                magazine.LoadMagazine();
            }
        }
    }


}
