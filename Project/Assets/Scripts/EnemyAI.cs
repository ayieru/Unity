using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour,IReceiveDamage
{
    private NavMeshAgent agent;

    private GameObject p;

    public EnemyData data;

    public int hp;
    public float speed;
    public int damage;
    public int point;
    private int t = 0;

    void Start()
    {
        p = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;

        agent.speed *= speed;
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(p.transform.position);

        if (t > 0)
        {
            agent.SetDestination(this.transform.position);
            t--;
        }

    }

    public void ReceiveDamage(int Pdamage)
    {
        hp -= Pdamage;
        if (hp <= 0) 
        {
            hp = 0;
            Destroy(gameObject);
        }

        Debug.Log("Enemy は " + Pdamage + "ダメージ食らった\n残りHP " + hp);

        t = Pdamage;
    }

    public void SetNum(int num)
    {
        hp = data.hp[num];
        speed = data.speed[num];
        damage = data.damage[num];
        point = data.point[num];
    }
}