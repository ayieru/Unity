using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDataUI : MonoBehaviour
{
    private Text t;

    public WeaponData preData;
    private int level;

    void Awake()
    {
        t = GetComponent<Text>();
    }

    public void UpdateData()
    {
        //前のデータ+１レベルのデータ取得
        level = preData.level[0];

        t.text = (preData.level[level]).ToString("") + "\n\n" +
                 (preData.damage[level]).ToString("") + "\n\n" +
                 (preData.ammo[level]).ToString("");
    }
}
