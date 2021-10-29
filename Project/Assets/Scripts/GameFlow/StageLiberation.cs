//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//// ステージが解放されるスクリプト
//public class StageLiberation : MonoBehaviour
//{

//    public int stage_num; // スコア変数
//    public GameObject ni;
//    public GameObject san;
//    public GameObject yon;
//    public GameObject go;


//    private void Go()
//    {
//        int clearLevel = PlayerPrefs.GetInt("SCORE", 0);

//        //レベルに応じてUI画像入れ替え
//        switch (clearLevel)
//        {
//            case 1:
//                ni.SetActive(true);
//                break;
//            case 2:
//                san.SetActive(true);
//                break;
//            case 3:
//                yon.SetActive(true);
//                break;
//        }
//    }

//        // Use this for initialization
//        void Start()
//    {
//        //現在のstage_numを呼び出す
//        stage_num = PlayerPrefs.GetInt("SCORE", 0);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //stage_numが２以上のとき、ステージ２を解放する。以下同様
//        //if (stage_num >= 2)
//        //{
//        //    ni.SetActive(true);
//        //}

//        //if (stage_num >= 3)
//        //{
//        //    san.SetActive(true);
//        //}

//        //if (stage_num >= 4)
//        //{
//        //    yon.SetActive(true);
//        //}

//        //if (stage_num >= 5)
//        //{
//        //    go.SetActive(true);
//        //}

//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageLiberation : MonoBehaviour
{
    //ステージ1はゲームスタート時に解放されているのでstage2から
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject stage5;

    static bool once = false;

    void Onlyonce()
    {
        if(!once)
        {
            PlayerPrefs.SetInt("stageNumber", 1);
            PlayerPrefs.Save();

            once = true;
        }

    }

    void Start()
    {
        Onlyonce();
    }


    void Update()
    {
        int stageNumber = PlayerPrefs.GetInt("stageNumber");

        Debug.Log(PlayerPrefs.GetInt("stageNumber"));

        if (stageNumber >= 2)
        {
            stage2.SetActive(true);
        }

        if (stageNumber >= 3)
        {
            stage3.SetActive(true);
        }

        if (stageNumber >= 4)
        {
            stage4.SetActive(true);
        }

        if (stageNumber >= 5)
        {
            stage5.SetActive(true);
        }


    }
}