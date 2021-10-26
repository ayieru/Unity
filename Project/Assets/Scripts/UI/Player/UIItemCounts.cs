using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemCounts : MonoBehaviour
{
    [SerializeField]
    private Player playerScript;
    private ItemData itemData;
    [SerializeField] private Player.EItem itemAttr;
    [SerializeField] Text itemText;
    Image image;
    [SerializeField] UIColor colorScript;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.currentItemAttr == itemAttr)
        {
            if(playerScript.GetItemCurrentNum() > 0)
            {
                image.color = colorScript.enableColor;
            }
            else
            {
                image.color = colorScript.unableColor;
            }
        }
        else
        {
            image.color = colorScript.color;
        }
        string text = playerScript.GetItemCurrentNum(itemAttr).ToString() + " / " + 
            playerScript.GetItemMaxNum(itemAttr).ToString();
        itemText.text = text;
    }
}
