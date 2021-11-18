using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCollision : MonoBehaviour
{
    public GameObject Board;

    private void Start()
    {
        Board.SetActive(false);
    }

    public void SetItem()
    {
        Board.SetActive(true);
    }
}
