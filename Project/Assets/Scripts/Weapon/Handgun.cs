using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
    new void Awake()
    {
        base.Awake();
        MazzuleFlash = MazzuleFlash.GetComponent<ParticleSystem>();
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

        if (Input.GetMouseButtonDown(0))

        {
            if (shootFlag && !reloadFrag)
            {
                if (magazine.LoadGun())
                {
                    audioSource.PlayOneShot(shot);
                    MazzuleFlash.Play();
                    // 上で取得した場所に、"bullet"のPrefabを出現させる
                    GameObject newBullet = Instantiate(magazine.bullet.gameObject, GetFPPosition(), magazine.bullet.transform.rotation);
                    GameObject newShell = Instantiate(magazine.shell.gameObject, GetFPPosition(), magazine.shell.transform.rotation);
                    // 出現させたボールのforward(z軸方向)
                    Vector3 direction = GetFPForward();
                    // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);
                    newBullet.GetComponent<Bullet>().SetPower((int)power);
                    newShell.GetComponent<Rigidbody>().AddForce(direction * 1f, ForceMode.Impulse);
                    // 出現させたボールの名前を"bullet"に変更
                    newBullet.GetComponent<Bullet>().playerScript = playerScript;
                    newBullet.name = magazine.bullet.gameObject.name;
                    shootFlag = false;
                    shootingFrag = true;
                }
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
                magazine.LoadMagazine();
            }
        }
    }
}
