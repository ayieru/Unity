using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour,Interface
{
    private NavMeshAgent agent;

    private GameObject p;

    private EnemyData data;

    private Vector3 tmp;
    private int EnemyNum;
    private int hp;
    private float speed;
    private int damage;
    private int point;

    void Awake()
    {
        p = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        agent.speed *= speed;
    }
    // Update is called once per frame
    void Update()
    {
        tmp = p.transform.position;
        agent.SetDestination(tmp);
    }

    public void ReceiveDamage(int Pdamage)
    {
        hp -= Pdamage;
        if (hp < 0) 
        {
            hp = 0;
            Destroy(gameObject);
        }

        Debug.Log("Enemy は " + Pdamage + "ダメージ食らった\n残りHP " + hp);
    }

    public void SetNum(int num)
    {
        //EnemyNum = num;
        //Debug.Log(EnemyNum);

        //hp = data.hp[EnemyNum];
        //speed = data.speed[EnemyNum];
        //damage = data.damage[EnemyNum];
        //point = data.point[EnemyNum];
    }
}