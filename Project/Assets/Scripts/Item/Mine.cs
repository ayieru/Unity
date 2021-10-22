using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int power;
    public float radius;
    public GameObject ex;

    private void OnCollisionEnter(Collision collision)
    {
        var p = collision.gameObject.GetComponent<IReceiveDamage>();

        if (p != null)
        {
            p.ReceiveDamage(power);

            Vector3 explosionPos = transform.position;

            ex.transform.position = explosionPos;
            Instantiate(ex, transform.position, transform.rotation);

            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 1000.0F);

                    var r = hit.gameObject.GetComponent<IReceiveDamage>();
                    if (r != null)
                    {
                        r.ReceiveDamage(power);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
