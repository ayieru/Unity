﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawn : MonoBehaviour
{
    //敵プレハブ
    public GameObject enemyPrefab;

    [SerializeField]
    //スポーン時間
    private int[] spawntime = new int[10];

    private float t;

    private int spawncount;

    //配列サイズ
    private int arraysize;

    // Start is called before the first frame update
    void Start()
    {
        arraysize = spawntime.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawncount < arraysize)
        {
            t = (float)Math.Round(Time.realtimeSinceStartup, 1, MidpointRounding.AwayFromZero);

            for (int i = 0; i < arraysize; i++)
            {
                if (spawntime[i] == t)
                {
                    GameObject enemy = Instantiate(enemyPrefab);
                    enemy.transform.position = this.gameObject.transform.position;
                    spawntime[i] = -1;
                    spawncount++;
                }
            }
        }
    }
}