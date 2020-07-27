using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerMainMenu : MonoBehaviour
{
    public AudioSource BGFx,ButtonFx;

    public static SoundManagerMainMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ButtonSoundPlay()
    {
        ButtonFx.Play();
    }

}
