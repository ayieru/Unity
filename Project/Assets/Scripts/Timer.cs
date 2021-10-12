using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public  float gameTime;
    private Text t;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //○分○.○秒で表示
        t.text = "残り " + ((int)gameTime / 60).ToString("0") + ":" + (gameTime % 60f).ToString("00.0");
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            gameTime = 0f;
        }
    }
}
