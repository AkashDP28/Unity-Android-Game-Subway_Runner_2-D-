using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dreamloTry : MonoBehaviour
{
    public InputField PlayerNameInputField;
    public GameObject PlayerNameInputFieldGO;

    dreamloLeaderBoard dl;

    private void Awake()
    {
        this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

        if (PlayerPrefs.GetInt("Name") == 0)
        {
            PlayerNameInputFieldGO.SetActive(true);
        }
        else
        {
            PlayerNameInputFieldGO.SetActive(false);
        }
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("Name") == 1)
        {
            dl.AddScore(PlayerNameInputField.text, 40);
        }
    }

    private void Update()
    {
        Enter();
       

    }
    private void OnGUI()
    {
        var width200 = new GUILayoutOption[] { GUILayout.Width(200) };
        GUILayout.Label("High Scores:");
        List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();

        if (scoreList == null)
        {
            GUILayout.Label("(loading...)");
        }
        else
        {
            int maxToDisplay = 20;
            int count = 0;
            foreach (dreamloLeaderBoard.Score currentScore in scoreList)
            {
                count++;
                GUILayout.BeginHorizontal();
                GUILayout.Label(currentScore.playerName, width200);
                GUILayout.Label(currentScore.score.ToString(), width200);
                GUILayout.EndHorizontal();

                if (count >= maxToDisplay) break;
            }
        }
    }

    public void Enter()
    {
        if (PlayerNameInputField.text != null)
        {
            dl.AddScore(PlayerNameInputField.text, 10);
            PlayerPrefs.SetInt("Name", 1);
        }
    }
}
