using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IReceiveDamage, IAddPoints
{
    private enum EnemyAiState
    {
        MOVE,　　　　　　//移動
        ATTACK,          //攻撃
        IDLE,            //待機
    }
    private EnemyAiState aiState = EnemyAiState.IDLE;
    private EnemyAiState nextState;

    public EnemyData data;
    public GameObject add;

    private NavMeshAgent agent;
    private GameObject p;
    private GameObject c;
    private int hp;
    private float speed;
    private int damage;
    private int point;
    private int type;
    private float t = 0.3f;
    private bool search = false;
    private float NEAR_DIR = 20f;

    void Start()
    {
        p = GameObject.Find("Player");

        SetNav();

        switch (type)
        {
            case 1:
                InvokeRepeating(nameof(UpdateAI_01), 0f, t);
                break;
            case 3:
                InvokeRepeating(nameof(UpdateAI_03), 0f, t);
                break;
            default:
                InvokeRepeating(nameof(UpdateAI), 0f, t);
                break;
        }
    }
    private void Update()
    {

    }

    public bool ReceiveDamage(int Pdamage)
    {
        bool deadFlag = false;
        hp -= Pdamage;
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
            deadFlag = true;
        }

        Debug.Log("Enemy は " + Pdamage + "ダメージ食らった\n残りHP " + hp);

        return deadFlag;
    }

    public int GetPoints()
    {
        return point;
    }

    public void SetNum(int num)
    {
        hp = data.hp[num];
        speed = data.speed[num];
        damage = data.damage[num];
        point = data.point[num];

        //1と3の場合は別AI
        type = num;
    }

    private void SetNav()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;

        agent.speed *= speed;
    }

    private void UpdateNav()
    {
        agent.SetDestination(p.transform.position);
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
            if (aiState == EnemyAiState.IDLE)
            {
                nextState = EnemyAiState.ATTACK;
            }
            else
            {
                nextState = EnemyAiState.IDLE;
            }
        }
        else
        {
             nextState = EnemyAiState.MOVE;
        }

        Debug.Log(aiState);
    }
    private void UpdateAI()
    {
        SetAi();
        switch (aiState)
        {
            case EnemyAiState.MOVE:
                UpdateNav();
                break;
            case EnemyAiState.ATTACK:
                Attack();
                break;
            case EnemyAiState.IDLE:
                Idle();
                break;
            default:
                break;
        }
    }
    private void UpdateAI_01()
    {
        SetAi();
        switch (aiState)
        {
            case EnemyAiState.MOVE:
                UpdateNav_01();
                break;
            case EnemyAiState.ATTACK:
                Attack();
                break;
            case EnemyAiState.IDLE:
                Idle();
                break;
            default:
                break;
        }
    }
    private void UpdateAI_03()
    {
        SetAi();
        switch (aiState)
        {
            case EnemyAiState.MOVE:
                UpdateNav_03();
                break;
            case EnemyAiState.ATTACK:
                Attack();
                break;
            case EnemyAiState.IDLE:
                Idle();
                break;
            default:
                break;
        }
    }

    private void UpdateNav_03()
    {
        agent.SetDestination(p.transform.position);
        damage = (int)data.damage[type];

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject obj in targets)
        {
            float dir = Vector3.Distance(obj.transform.position, transform.position);
            if (dir < NEAR_DIR)
            {
                agent.SetDestination(obj.transform.position);
                damage = (int)data.add[type];
                break;
            }
        }
    }

    private void Idle()
    {
        agent.SetDestination(transform.position);
    }

    private void Attack()
    {
        if (search)
        {
            var v = c.gameObject.GetComponent<IReceiveDamage>();

            if (c != null && v != null)
            {
                v.ReceiveDamage(damage);
                Debug.Log(c.ToString() +"は" + damage + "ダメージくらった");
            }
            search = false;
        }
    }

    private void UpdateNav_01()
    {
        float dir = Vector3.Distance(p.transform.position, transform.position);
        if (dir < 15)
        {
            agent.SetDestination(transform.position);
            GameObject t = transform.Find("target").gameObject;
            Instantiate(add, t.transform.position, transform.rotation);
            add.GetComponent<rock>().SetTarget(p.transform.position);
        }
        else
        {
            agent.SetDestination(p.transform.position);
            search = false;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Item"))
        {
            search = true;
            c = collider.gameObject;
        }
        else
        {
            search = false;
        }
    }
}