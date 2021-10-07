using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //敵プレハブ
    public GameObject enemyPrefab;

    //経過時間
    private float time;

    //配列サイズ
    private int arraysize;

    [SerializeField]
    //スポーン時間
    private float[] spawntime = new float[10];

    // Start is called before the first frame update
    void Start()
    {
        arraysize = spawntime.Length;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.frameCount % 60f;
        
        for(int i = 0; i < arraysize; i++)
        {
            if (spawntime[i] == time)
            {
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position = this.gameObject.transform.position;
            }
        }
    }
}