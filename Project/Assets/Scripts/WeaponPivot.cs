using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPivot : MonoBehaviour
{
    public GameObject playerGB;
    public float TargetDistance;

    public float gizmoSize = 0.3f;
    public Color gizmoColor = Color.yellow;

    private void Start()
    {
        Vector3 distance = playerGB.transform.forward * TargetDistance;
        Vector3 target;
        target.x = playerGB.transform.position.x + distance.x;
        target.z = playerGB.transform.position.z + distance.z;
        target.y = transform.position.y + distance.y;

        transform.LookAt(target);
    }

    private void Update()
    {
        Debug.DrawRay(playerGB.transform.position, playerGB.transform.forward * 10, Color.green);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
