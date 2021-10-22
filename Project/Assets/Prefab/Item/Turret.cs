using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Turret : MonoBehaviour
{
    private enum TurretAiState
    {
        SEARCH,          //探索
        ATTACK,          //攻撃
        IDLE,            //待機
    }

    public GameObject ammo;
    public float NEAR_DIR = 0;

    private GameObject p;
    private TurretAiState aiState = TurretAiState.IDLE;
    private TurretAiState nextState;

    private bool search = false;

    private void Start()
    {

    }

    private void Update()
    {
        UpdateAI();
    }

    private void SetAi()
    {
        AiMainRoutine();
        aiState = nextState;

    }

    private void AiMainRoutine()
    {
        if (search)
        {
            nextState = TurretAiState.ATTACK;
        }
        else
        {
            nextState = TurretAiState.SEARCH;
        }
    }

    private void UpdateAI()
    {
        SetAi();
        switch (aiState)
        {
            case TurretAiState.SEARCH:
                Search();
                break;
            case TurretAiState.ATTACK:
                Attack();
                break;
            case TurretAiState.IDLE:
                Idle();
                break;
            default:
                break;
        }
    }

    private void Search()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in targets)
        {
            float dir = Vector3.Distance(obj.transform.position, transform.position);
            if (dir < NEAR_DIR)
            {
                search = true;
                p = obj;
            }
        }
    }

    private void Attack()
    {
        if (p != null)
        {
            transform.LookAt(p.transform);
        }
        Shoot();

        search = false;
    }

    private void Idle()
    {
        throw new NotImplementedException();
    }

    private void Shoot()
    {
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newAmmo = Instantiate(ammo.gameObject, transform.position, transform.rotation);
        ammo.GetComponent<Ammo>().SetPower(30);
        // 出現させたボールのforward(z軸方向)
        Vector3 direction = transform.forward;
        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newAmmo.GetComponent<Rigidbody>().AddForce(direction * 70, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newAmmo.name = ammo.gameObject.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newAmmo, 0.8f);
    }

    private IEnumerator DelayCoroutine()
    {
        for (var i = 0; i < 60; i++)
        {
            yield return null;
        }
    }
}
