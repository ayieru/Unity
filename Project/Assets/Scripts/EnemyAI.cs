using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Vector3 tmp;

    private NavMeshAgent agent;

    private GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        tmp = p.transform.position;
        agent.SetDestination(tmp);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet") 
        { 
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}