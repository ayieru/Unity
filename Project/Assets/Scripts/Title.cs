using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;　//シーンマネージャー呼び出し

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //スタートボタンを押すとセレクト画面に切り替わる
    public void StartBt()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
