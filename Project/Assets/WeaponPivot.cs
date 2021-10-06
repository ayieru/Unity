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

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 target = playerGB.transform.forward * TargetDistance + new Vector3(0f, transform.position.y, 0f);
            transform.LookAt(target);
            Debug.Log(playerGB.transform.forward);
        }
        Debug.DrawRay(playerGB.transform.position, playerGB.transform.forward * 10, Color.green);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
