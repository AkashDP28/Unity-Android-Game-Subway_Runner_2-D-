using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckersScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameManager.instance.IsPlayerDead = true;
            SoundManager.instance.DeadSoundPlay();
           // GameManager.instance.LoadMainMenu();
            LevelLoader.instance.LoadLevel(0);
            //   PlayerPrefs.SetInt("CoinRun", PlayerSafe.CoinCount);

            PlayerPrefs.SetInt("CoinRun", PlayerSafe.instance.CoinRun);
            MetreScript.TakeMeter = true;
            
            PlayerSafe.Double = false;

          /*  ADManager.instance.DisplayInterstitialAfterSomeTime();
            ADManager.instance.DisplayRewardedAfterSomeTime();*/
            // MenuP.instance.Trigged();
        }
    }
}
