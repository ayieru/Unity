using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Install()
    {
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        transform.parent = null;
        this.gameObject.AddComponent<Rigidbody>();
    }
}
