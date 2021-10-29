using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
    }
}
