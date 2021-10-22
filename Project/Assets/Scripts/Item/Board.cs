using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour,IReceiveDamage
{
    public ItemData data;
    private int hp;

    void Start()
    {
        hp = data.hp[1];
    }

    public bool ReceiveDamage(int Pdamage)
    {
        bool deadFlag = false;
        hp -= Pdamage;
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
            deadFlag = true;
        }

        Debug.Log("Board は " + Pdamage + "ダメージ食らった\n残りHP " + hp);

        return deadFlag;
    }
}
