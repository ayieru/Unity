﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEx : MonoBehaviour
{
    [SerializeField] GameObject P_Update;
    [SerializeField] GameObject preData;
    [SerializeField] GameObject updateData;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        P_Update.SetActive(false);

        //イベントトリガー作成
        button = GetComponent<Button>();
        button.gameObject.AddComponent<EventTrigger>();
        var trigger = button.GetComponent<EventTrigger>();

        //登録するイベントを設定
        var mouseOver = new EventTrigger.Entry();
        mouseOver.eventID = EventTriggerType.PointerEnter;
        mouseOver.callback.AddListener((data) => { MouseOver(); });

        var mouseExit = new EventTrigger.Entry();
        mouseExit.eventID = EventTriggerType.PointerExit;
        mouseExit.callback.AddListener((data) => { MouseExit(); });

        //トリガーに機能追加
        trigger.triggers.Add(mouseOver);
        trigger.triggers.Add(mouseExit);
    }

    void MouseOver() 
    {
        preData.GetComponent<PreviousDataUI>().PreviousData();
        updateData.GetComponent<UpdateDataUI>().UpdateData();
        P_Update.SetActive(true);
    }

    void MouseExit()
    {
        P_Update.SetActive(false);
    }
}
