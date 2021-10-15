using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    public override void Shoot()
    {
        if (magazine.LoadGun())
        {
            // 上で取得した場所に、"bullet"のPrefabを出現させる
            GameObject newAmmo = Instantiate(magazine.ammo.gameObject, GetFPPosition(), transform.rotation);
            // 出現させたボールのforward(z軸方向)
            Vector3 direction = GetFPForward();
            // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
            newAmmo.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);
            // 出現させたボールの名前を"bullet"に変更
            newAmmo.name = magazine.ammo.gameObject.name;
            // 出現させたボールを0.8秒後に消す
            Destroy(newAmmo, 0.8f);
        }
    }
}
