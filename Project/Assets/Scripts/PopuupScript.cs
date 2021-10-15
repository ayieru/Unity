using System.Collections;
using System.Collections.Generic; using UnityEngine;
using UnityEngine.UI;//UnityのUI（buttonなどの機能）を使用するおまじない


public class PopupScript : MonoBehaviour
{
    public GameObject Popup;//Popupというゲームオブジェクトを宣言する

    // Use this for initialization
    void Start()
    {
     }

    // Update is called once per frame
    void Update()
    {

    }

    //Appear関数が呼び出されるとポップアップが表示される
    public void Appear()
    {
        Popup.SetActive(true);
    }

    //Delete関数が呼び出されるとポップアップが非表示になる
    public void Delete()
    {
        Popup.SetActive(false);
    }
}