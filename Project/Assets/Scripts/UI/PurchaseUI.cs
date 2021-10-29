using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseUI : MonoBehaviour
{
    public ItemData data;

    private GameObject image;
    private GameObject text;
    private int itemNum;

    public void SetNum(string t)
    {
        for(int i = 0; i < data.itemname.Length; i++)
        {
            if (t == data.itemname[i])
            {
                itemNum = i;
                break;
            }
        }
        Debug.Log(itemNum);

        image = transform.Find("Panel").gameObject;
        text = transform.Find("Text").gameObject;

        image.GetComponent<Image>().sprite = data.image[itemNum];
        text.GetComponent<Text>().text = data.text[itemNum];
    }
}
