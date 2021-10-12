using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousDataUI : MonoBehaviour
{
    private Text t;

    public WeaponData preData;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        //現在のレベル
        level = 0;
        t = GetComponent<Text>();
    }

    public void PreviousData()
    {
        t.text = (preData.level[level]).ToString("") + "\n\n" +
                 (preData.damage[level]).ToString("") + "\n\n" +
                 (preData.ammo[level]).ToString("");
    }
}
