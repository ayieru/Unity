using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンをロードする場合に必要

// ゴールした時にstage_numの値が変更されるようにするためのスクリプト
public class LiberationScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Player")
    //    {
    //        //PlayerPrefsのSCOREに3という値を入れる
    //        PlayerPrefs.SetInt("SCORE", 3);
    //        //PlayerPrefsをセーブする         
    //        PlayerPrefs.Save();

    //    }
    //}
    private int stageNum;
    public void StageOpen()
    {
        PlayerPrefs.SetInt("stageNumber", stageNum);//PlayerPrefsでクリアしたステージ番号をセット
    }

    //public void push()
    //{
    //    //PlayerPrefsのSCOREに3という値を入れる
    //    PlayerPrefs.SetInt("SCORE", 3);
    //    //PlayerPrefsをセーブする         
    //    PlayerPrefs.Save();

    //    SceneManager.LoadScene("StageSelect");
    //}
}