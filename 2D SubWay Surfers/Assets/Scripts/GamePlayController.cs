using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PlayButton;
    public GameObject PauseButton;
    public GameObject QuitPanel;

    public void Pause()
    {
        PausePanel.SetActive(true);
        PlayButton.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
        SoundManager.instance.ButtonSoundPlay();
    }

    public void Play()
    {
        PausePanel.SetActive(false);
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        SoundManager.instance.ButtonSoundPlay();
    }

    public void Exit()
    {
        PausePanel.SetActive(false);
        QuitPanel.SetActive(true);
        SoundManager.instance.ButtonSoundPlay();
    }
    
    public void Yes()
    {
        Time.timeScale = 1f;
        //  SceneManager.LoadScene("MainMenu");
        LevelLoader.instance.LoadLevel(0);
        SoundManager.instance.ButtonSoundPlay();
        PlayerPrefs.SetInt("CoinRun", 0);
        PlayerPrefs.SetInt("CurrentMeter", 0);
    }

    public void No()
    {
        QuitPanel.SetActive(false);
        PausePanel.SetActive(true);
        SoundManager.instance.ButtonSoundPlay();
    }

    
}
