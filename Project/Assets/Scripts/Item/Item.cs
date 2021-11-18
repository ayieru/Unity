using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void Install()
    {
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        transform.parent = null;
        this.gameObject.AddComponent<Rigidbody>();
    }
}
