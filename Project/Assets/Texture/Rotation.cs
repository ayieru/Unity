using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float a = 0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 1f), 0.3f);
        transform.position += new Vector3(0f, Mathf.Sin(a * 0.01f ) * 0.001f, 0f);
        a++;
    }
}
