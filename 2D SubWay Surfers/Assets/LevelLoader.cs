using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;

    public static LevelLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(LoadLevelAsync(SceneIndex));
    }
    IEnumerator LoadLevelAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float Progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = Progress;
            yield return null;
        }
    }
}
