using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    void Awake()
    {
        Destroy(this.gameObject, 2f);
    }
}
