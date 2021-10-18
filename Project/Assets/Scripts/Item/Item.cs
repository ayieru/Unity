using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Install(Vector3 position)
    {
        transform.position = position;
    }
}
