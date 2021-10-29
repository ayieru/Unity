using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;　//シーンマネージャー呼び出し


// GameOver スクリプト
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // タイトルに移動
    public void TitleBt()
    {
        SceneManager.LoadScene("Title");
    }

    public void Re(int Stage)
    {
        SceneManager.LoadScene("stage" + Stage);
    }

    public void Retry(string stagename)
    {
        SceneManager.LoadScene(stagename);
    }
}
