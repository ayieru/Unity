﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCollision : MonoBehaviour
{
    public GameObject Board;

    private void Start()
    {
        Board.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Board.SetActive(true);
        }
    }
}
