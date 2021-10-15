using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPivot : MonoBehaviour
{
    GameObject GOplayer;

    [SerializeField]
    float targetDistance;

    [SerializeField]
    float gizmoSize = 0.3f;

    [SerializeField]
    Color gizmoColor = Color.yellow;

    private void Start()
    {
        GOplayer = transform.parent.gameObject;
        Vector3 distance = GOplayer.transform.forward * targetDistance;
        Vector3 target;
        target.x = GOplayer.transform.position.x + distance.x;
        target.z = GOplayer.transform.position.z + distance.z;
        target.y = transform.position.y + distance.y;

        transform.LookAt(target);
    }

    private void Update()
    {
        Debug.DrawRay(GOplayer.transform.position, GOplayer.transform.forward * 10, Color.green);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
