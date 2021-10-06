using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    private RectTransform reticle;

    [Range(200f, 300f)]
    public float size;

    public float restingSize;
    public float maxSize;
    public float speed;

    public float curtSize;

    private void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //playerのrigidbody.velocityでもいい
        if (isMoving())
        {
            curtSize = Mathf.Lerp(curtSize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            curtSize = Mathf.Lerp(curtSize, restingSize, Time.deltaTime * speed);
        }

        reticle.sizeDelta = new Vector2(curtSize, curtSize); 
    }

    bool isMoving()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
