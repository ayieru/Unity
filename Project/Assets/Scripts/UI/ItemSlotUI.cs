using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public ItemData data;

    private int itemNum;

    public void SetNum(string t)
    {
        for (int i = 0; i < data.itemname.Length; i++)
        {
            if (t == data.itemname[i])
            {
                itemNum = i;
                break;
            }
        }
        Debug.Log(itemNum);

        GetComponent<Image>().sprite = data.image[itemNum];
    }
}
