using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPivot : MonoBehaviour
{
    public GameObject playerGO;
    public float targetDistance;

    public float gizmoSize = 0.3f;
    public Color gizmoColor = Color.yellow;

    private void Start()
    {
        Vector3 distance = playerGO.transform.forward * targetDistance;
        Vector3 target;
        target.x = playerGO.transform.position.x + distance.x;
        target.z = playerGO.transform.position.z + distance.z;
        target.y = transform.position.y + distance.y;

        transform.LookAt(target);
    }

    private void Update()
    {
        Debug.DrawRay(playerGO.transform.position, playerGO.transform.forward * 10, Color.green);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
