using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSafe : MonoBehaviour
{
    public int CoinCount=0,CoinRun;

    public Text CoinText;
    public static bool Double;

    public static PlayerSafe instance;

   public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        CoinRun = CoinCount;
    }

    private void Update()
    {
        CoinText.text = CoinRun.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            if (Double)
            {
                CoinRun += 2;
            }
            else
            {
                CoinRun++;
            }
            SoundManager.instance.CoinSoundPlay();
             // CoinText.text = CoinRun.ToString();
          //  CoinText.text = PlayerPrefs.GetInt("CoinRun").ToString();
        }
    }
}
