using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private void Start()
    {
        transform.parent.gameObject.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.parent.gameObject.SetActive(true);
            Debug.Log("enter");
        }
        Debug.Log("enter");
    }
}
