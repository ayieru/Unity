using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create WeaponData")]

public class WeaponData : ScriptableObject
{
	static int count = 3;

	public string weaponName;
	public int[] level = new int[count];
	public int[] damage = new int[count];
	public int[] headShot = new int[count];
	public int[] cost = new int[count];
	public int[] rate = new int[count];
	public int[] add = new int[count];
}
