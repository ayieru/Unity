using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create WeaponMasterData")]

public class W_MasterData : ScriptableObject
{
	static int count = 4;

	public WeaponData[] data = new WeaponData[count];
	public string[] weaponName = new string[count];
}