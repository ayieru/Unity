using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    private UIManager UImanager;
    private GameObject p;
    private bool state;

    private void Start()
    {
        UImanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        state = false;
    }

    private void Update()
    {
        if(state && p != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UImanager.SetWorkbench();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        p = other.gameObject;

        if (p.CompareTag("Player"))
        {
            state = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UImanager.ReturnUI();
        state = false;
    }
}
