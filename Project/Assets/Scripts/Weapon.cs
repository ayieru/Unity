using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int level;

    public Weapon(string name, int level)
    {
        this.name = name;
        this.level = level;
    }
}
