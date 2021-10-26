using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour
{
    [SerializeField] Player playerScript;

    Text pointText;
    // Start is called before the first frame update
    void Start()
    {
        pointText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = playerScript.points.ToString().PadLeft(4);
        pointText.text = text;
    }
}
