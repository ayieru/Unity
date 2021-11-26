using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
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
        if (Input.GetMouseButtonDown(0))
        {
            if (shootFlag && !reloadFrag)
            {
                if (magazine.LoadGun())
                {
                    audioSource.PlayOneShot(shot);
                    MazzuleFlash.Play();

                    Vector3 direction = GetFPForward();
                    Vector3 force = new Vector3(0f, 0f, 0f);

                    //フォース変更ｙ、シェルのランダム生成、方向ベクトル

                    for (int cnt = 0; cnt < 10; cnt++)
                    {
                        float random1 = Random.Range(0.1f, -0.1f);
                        float random2 = Random.Range(0.1f, -0.1f);
                        float random3 = Random.Range(0.1f, -0.1f);
                        force = new Vector3(random1, random2, random3);

                        GameObject bullet = Instantiate(magazine.bullet.gameObject, GetFPPosition(), magazine.bullet.transform.rotation);
                        magazine.bullet.GetComponent<Bullet>().SetPower((int)power);
                        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                        bulletRb.AddForce(direction/100, ForceMode.Impulse);
                        bulletRb.AddForce(force);
                    }

                    GameObject newShell = Instantiate(magazine.shell.gameObject, magazine.transform.position, magazine.shell.transform.rotation);
                    // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
                    newShell.GetComponent<Rigidbody>().AddForce(direction * 1f, ForceMode.Impulse);

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
