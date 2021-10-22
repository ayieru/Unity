using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    //敵データ
    public EnemyData enemyData;

    //スポーン時間
    [SerializeField]
    private int[] spawntime = new int[10];

    //敵タイプ
    [SerializeField]
    private int[] enemyNum = new int[10];

    private float realTime;
    private float t;

    private int spawncount;

    //配列サイズ
    private int arraysize;

    // Start is called before the first frame update
    void Start()
    {
        realTime = 0;
        arraysize = spawntime.Length;
    }

    // Update is called once per frame
    void Update()
    {
        realTime += Time.deltaTime;

        if (spawncount < arraysize)
        {
            t = (float)Math.Round(realTime, 1, MidpointRounding.AwayFromZero);

            for (int i = 0; i < arraysize; i++)
            {
                if (spawntime[i] == t)
                {
                    GameObject enemy = Instantiate(enemyData.enemy[enemyNum[i] - 1]);
                    enemy.GetComponent<EnemyAI>().SetNum(enemyNum[i] - 1);
                    enemy.transform.position = this.gameObject.transform.position;
                    enemy.transform.rotation = this.gameObject.transform.rotation;
                    spawntime[i] = -1;
                    spawncount++;
                }
            }
        }
    }
}