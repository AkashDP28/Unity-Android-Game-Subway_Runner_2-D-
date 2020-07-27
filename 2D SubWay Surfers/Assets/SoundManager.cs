using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGFx, coinFx, BonusFx, MagnetFX, RedFx, BlueFx,DeadFX,ButtonFx;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void CoinSoundPlay()
    {
        coinFx.Play();
    }

    public void MagnetSoundPlay()
    {
        MagnetFX.Play();
    }

    public void BonusSoundPlay()
    {
        BonusFx.Play();
    }
   
    public void RedSoundPlay()
    {
        RedFx.Play();
    }

    public void BlueSoundPlay()
    {
        BlueFx.Play();
    }

    public void DeadSoundPlay()
    {
        DeadFX.Play();
    }

    public void ButtonSoundPlay()
    {
        ButtonFx.Play();
    }
}
