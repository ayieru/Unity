using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]

public class EnemyData : ScriptableObject
{
	static int count = 5;

	public GameObject[] enemy = new GameObject[count];
	public int[]   hp     = new int[count];
	public float[] speed  = new float[count];
	public int[]   damage = new int[count];
	public int []  point  = new int [count];
	public float[] add    = new float[count];
}
