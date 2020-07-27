using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public static Quit instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int BuildIndex = currentScene.buildIndex;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (BuildIndex == 0)
            {
                Application.Quit();
            }
            if (BuildIndex == 1)
            {
                SceneManager.LoadScene(BuildIndex - 1);
                PlayerPrefs.SetInt("CoinRun", 0);
                PlayerPrefs.SetInt("CurrentMeter", 0);
            }
        }

        if (BuildIndex == 0)
        {
            ADManager.instance.Display_Banner();
        }
        if (BuildIndex == 1)
        {
            ADManager.instance.StopBannerAd();
        }
    }
}
