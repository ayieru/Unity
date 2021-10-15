using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create ItemData")]

public class ItemData : ScriptableObject
{
	static int count = 5;

	public GameObject[] item = new GameObject[count];
	public Sprite[] image = new Sprite[count];
    public string[] itemname = new string[count];
	public int[] hp     = new int[count];
	public int[] cost   = new int[count];
	public int[] damage = new int[count];
	public int[] max = new int[count];
	public string[] text = new string[count];

	public float[] add  = new float[count];
}
