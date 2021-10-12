using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    // 体力
    public float maxHp { get; private set; }
    public float currentHp { get; private set; }

    void Start()
    {
        maxHp = 100;
        currentHp = maxHp;

        MovementStart();
        CameraStart();
    }

    void Update()
    {
        MovementUpdate();
        CameraUpdate();
    }

    private void FixedUpdate()
    {
        MovementFixedUpdate();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHp -= 10f;
            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        }
    }

}
