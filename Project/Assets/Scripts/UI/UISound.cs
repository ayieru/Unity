using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public GameObject g;

    private UIManager.UI_State state;
    private UIManager.UI_State nextState;
    private UIManager u;

    //サウンド
    public AudioClip sound;
    protected AudioSource audioSource;

    private void Start()
    {
        u = g.GetComponent<UIManager>();
        state = u.state;
        nextState = u.state;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (state != nextState)
        {
            audioSource.PlayOneShot(sound);
            nextState = u.state;
        }
        state = u.state;
    }
}
