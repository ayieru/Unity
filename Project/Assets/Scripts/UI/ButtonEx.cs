using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEx : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.gameObject.AddComponent<EventTrigger>();
        var trigger = button.GetComponent<EventTrigger>();

        //登録するイベントを設定
        var mouseOver = new EventTrigger.Entry();
        mouseOver.eventID = EventTriggerType.PointerEnter;
        mouseOver.callback.AddListener((data) => { MouseOver(); });

        //トリガーにマウスオーバー機能追加
        trigger.triggers.Add(mouseOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MouseOver() 
    {
        
    }
}
