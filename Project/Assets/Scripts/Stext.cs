using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stext : MonoBehaviour
{
    private Text t;

    void Awake()
    {
        t = GetComponent<Text>();
        t.text = SceneManager.GetActiveScene().name + (" Clear!!");
    }
}
