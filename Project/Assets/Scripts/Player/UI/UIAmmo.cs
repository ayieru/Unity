using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    Player playerScript;
    Text ammoText;

    private int maxCapacity;
    private int currentAmmoNum;
    // Start is called before the first frame update
    void Start()
    {
        ammoText = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = "Ammo  " + playerScript.weapon[0].weaponScript.magazine.currentAmmoNum.ToString().PadRight(2) + "/" + " ∞ ";
                        
        ammoText.text = text;

        Debug.Log(ammoText.text);
    }
}
