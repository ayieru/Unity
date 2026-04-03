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