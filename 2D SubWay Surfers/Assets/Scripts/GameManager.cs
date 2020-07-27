using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public bool IsPlayerDead;
    private void Awake()
    {
        if (instance != null)
        {
              Destroy(gameObject);
         //   DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
        IsPlayerDead = false;
        Debug.Log("hmmmm");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
