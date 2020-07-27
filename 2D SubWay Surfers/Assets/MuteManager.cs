using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteManager : MonoBehaviour
{
    private bool IsMuted;
    // public GameObject button;
    public GameObject[] images;
    void Start()
    {
     //   button.GetComponent<Image>().sprite = Sprite.
      //  transform.GetComponent<Image>
        IsMuted = PlayerPrefs.GetInt("Muted") == 1;
        AudioListener.pause = IsMuted;
        images[0].SetActive(IsMuted);
        images[1].SetActive(!IsMuted);
       // images[PlayerPrefs.GetInt("Muted")].SetActive(true);
    }

    public void MutePressed()
    {
        IsMuted = !IsMuted;
        AudioListener.pause = IsMuted;
        PlayerPrefs.SetInt("Muted", IsMuted ? 1 : 0);
        images[0].SetActive(IsMuted);
        images[1].SetActive(!IsMuted);
        //  images[PlayerPrefs.GetInt("Muted")].SetActive(true);
        //   AdManager.instance.ShowRewardedvideoAdTen();
        ADManager.instance.DisplayInterstitialAfterSomeTime();
        ADManager.instance.DisplayRewardedAfterSomeTime();
    }

}
