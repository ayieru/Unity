using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
	private Vector3 p;
	private int power = 25;

	private void Start()
    {
		{
			//float x0 = 10f, y0 = 10f, z0 = 10f;

			//Vector2 vec = new Vector2(transform.position.x, transform.position.y);
			//Vector2 p_vec = new Vector2(p.x, p.y);

			//Vector2 zvec = new Vector2(transform.position.x, transform.position.z);
			//Vector2 zp_vec = new Vector2(p.x, p.z);

			////X-Z
			//float zdir = Vector2.Distance(zvec, zp_vec);

			//float zAsinX = (zdir * 9.8f) / (x0 * z0);
			//if (zAsinX >= 1) zAsinX = 1.0f;

			//float ztheta = 0.5f * Mathf.Asin(zAsinX);


			//Rigidbody rb = GetComponent<Rigidbody>();

			//float dir = Vector2.Distance(vec, p_vec);

			//float AsinX = (dir * 9.8f) / (x0 * y0);
			//if (AsinX >= 1) AsinX = 1.0f;

			//float theta = 0.5f * Mathf.Asin(AsinX);
			//Vector3 v = rb.velocity;
			//v.x = x0 * Mathf.Cos(theta);
			//v.y = y0 * Mathf.Sin(theta);
			//rb.velocity = v;
		}
		Vector3 direction = transform.forward;
		GetComponent<Rigidbody>().AddForce(direction * 30, ForceMode.Impulse);
		Destroy(gameObject, 0.8f);
	}

	public void SetTarget(Vector3 tar)
    {
		p = tar;
    }

	void OnTriggerEnter(Collider collider)
	{
		var g = collider.gameObject.GetComponent<IReceiveDamage>();

		if (g != null)
		{
			if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Item"))
			{
				g.ReceiveDamage(power);
				Destroy(gameObject);
			}
		}
	}
}
