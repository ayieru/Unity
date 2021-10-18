using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEx : MonoBehaviour
{
    [SerializeField] GameObject P_Update;
    [SerializeField] GameObject preData;
    [SerializeField] GameObject updateData;
    [SerializeField] Text text;
    [SerializeField] GameObject slot;

    private Button button;
    private GameObject pre;
    private GameObject aff;
    private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        P_Update.SetActive(true);

        pre = GameObject.Find("UI_Update/P_Update/Data_pre");
        aff = GameObject.Find("UI_Update/P_Update/Data_aff");
        item = GameObject.Find("UI_ObjectShop/P_ObjectShop/P_Purchase");

        P_Update.SetActive(false);

        //イベントトリガー作�??
        button = GetComponent<Button>();
        button.gameObject.AddComponent<EventTrigger>();
        var trigger = button.GetComponent<EventTrigger>();

        //登録するイベントを設�?
        var mouseOver = new EventTrigger.Entry();
        mouseOver.eventID = EventTriggerType.PointerEnter;
        mouseOver.callback.AddListener((data) => { MouseOver(); });

        var mouseExit = new EventTrigger.Entry();
        mouseExit.eventID = EventTriggerType.PointerExit;
        mouseExit.callback.AddListener((data) => { MouseExit(); });

        //トリガーに機�?�追�?
        trigger.triggers.Add(mouseOver);
        trigger.triggers.Add(mouseExit);
    }

    void MouseOver() 
    {
        if (pre != null && aff != null)
        {
            pre.GetComponent<PreviousDataUI>().PreviousData();
            aff.GetComponent<UpdateDataUI>().UpdateData();
        }

        if (text != null)
        {
            item.GetComponent<PurchaseUI>().SetNum((string)text.text);
        }

        P_Update.SetActive(true);
    }

    void MouseExit()
    {
        P_Update.SetActive(false);
    }


    //クリ�?クされた時の処�?
    public void Barricade()
    {

    }

    public void Board()
    {
        slot.GetComponent<ItemSlotUI>().SetNum(text.text);
    }

    public void Landmine()
    {
        slot.GetComponent<ItemSlotUI>().SetNum(text.text);
    }

    public void Turret()
    {
        slot.GetComponent<ItemSlotUI>().SetNum(text.text);
    }

    public void Portion()
    {
        slot.GetComponent<ItemSlotUI>().SetNum(text.text);
    }
}
