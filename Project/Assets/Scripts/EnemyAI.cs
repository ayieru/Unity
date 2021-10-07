using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Vector3 tmp;
    NavMeshAgent agent;
    GameObject e;

    // Start is called before the first frame update
    void Start()
    {
        e = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        tmp = e.transform.position;
        agent.SetDestination(tmp);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { 
            Destroy(gameObject);
        }
    }
}