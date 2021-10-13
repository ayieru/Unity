using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾")]
    private GameObject GO_firingPoint;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 30f;

    public float power;

    void Start()
    {
        
    }

    void Update()
    {
        // スペースキーが押されたかを判定
        if (Input.GetMouseButtonDown(0))
        {
            // 弾を発射する
            Shoot();
        }
    }

    private void Shoot()
    {
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBullet = Instantiate(bullet, GetFPPosition(), transform.rotation);
        // 出現させたボールのforward(z軸方向)
        Vector3 direction = GetFPForward();
        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBullet.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBullet.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBullet, 0.8f);
    }

    private Vector3 GetFPPosition()
    {
        Vector3 position;

        if (GO_firingPoint == null)
        {
            position = transform.position;
        }
        else
        {
            position = GO_firingPoint.transform.position;
        }

        return position;
    }

    private Vector3 GetFPForward()
    {
        Vector3 forward;

        if (GO_firingPoint == null)
        {
            forward = transform.forward;
        }
        else
        {
            forward = GO_firingPoint.transform.forward;
        }

        return forward;
    }

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<EnemyAI>().ReceiveDamage(20);
    }

}
