using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject ex;
    public float power;
    public float radius;

    private void OnCollisionEnter(Collision collision)
    {
        var p = collision.gameObject.GetComponent<IReceiveDamage>();

        if (p != null)
        {
            p.ReceiveDamage((int)power);

            Vector3 explosionPos = transform.position;

            ex.transform.position = explosionPos;
            ex.GetComponent<ParticleSystem>().Play();

            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                Debug.Log(rb);

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 300.0F);

                    var r = collision.gameObject.GetComponent<IReceiveDamage>();
                    if (p != null)
                    {
                        p.ReceiveDamage((int)power);
                    }
                }
            }
        }
    }
}
