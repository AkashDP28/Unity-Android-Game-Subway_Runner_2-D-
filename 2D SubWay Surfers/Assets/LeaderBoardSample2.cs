using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderBoardSample2 : MonoBehaviour
{
    string dreamloWebserviceURL = "http://dreamlo.com/lb/";

    public bool IUpgradedAndGotSSL = false;
    public string privateCode = "8I0PU1cwBkSMsPt4zIS_Jwe57IXBGsQUOdvoaLd1qpfw";
    public string publicCode = "5efd89fe377eda0b6c9f1a20";


    DreamloLeaderBoard2 dl;
    enum gameState
    {
        waiting,
        running,
        enterscore,
        leaderboard
    };
    gameState gs;


    string playerName = "";
    void Start()
    {
        // get the reference here...
        this.dl = DreamloLeaderBoard2.GetSceneDreamloLeaderboard();



        this.gs = gameState.waiting;
    }


    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            this.gs = gameState.enterscore;
        }

    }

    void OnGUI()
    {
        var width200 = new GUILayoutOption[] { GUILayout.Width(Screen.width / 2.66f) };

      //  var width = 200;  // Make this wider to add more columns
     //   var height = 440;


        //   var r = new Rect( (width / 8), (Screen.height / 2) - (height / 2), width * 2 - 50, height);
        var r = new Rect(25,20,Screen.width/2-25,Screen.height-50);
        GUILayout.BeginArea(r, new GUIStyle("box"));
        GUI.skin.label.fontSize = (int)Screen.width / 45;
        GUI.skin.button.fontSize = (int)Screen.width / 45;

        GUILayout.BeginVertical();

        if (this.gs == gameState.waiting || this.gs == gameState.running)
        {

            GUILayout.Label("CLICK HERE TO CREATE YOUR USER_NAME");

        }



        if (this.gs == gameState.enterscore)
        {

            if (PlayerPrefs.GetInt("HasName") == 0)
            {
                GUILayout.BeginHorizontal();

               // GUILayout.Label("Your Name: ");
                this.playerName = GUILayout.TextField(this.playerName, width200);
                GUI.skin.textField.fontSize = (int)Screen.width / 45;



                if (GUILayout.Button("Submit"))
                {
                    // add the score...
                    if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
                    if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");


                    dl.AddScore(this.playerName, PlayerPrefs.GetInt("HighScoreMeter"));
                    PlayerPrefs.SetInt("HasName", 1);
                    this.gs = gameState.leaderboard;
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                //New Try
                GUILayout.Label("\n                  Enter Your Name\n" + "\nThis will be your User_Name for all time" + "\nYou will not be able to rename it " + "\n" + "\nPlease Create your Unique User_Name");
                PlayerPrefs.SetString("PlayerName", playerName);
                GUILayout.EndHorizontal();
            }

            else if (PlayerPrefs.GetInt("HasName") == 1)
            {
                GUILayout.Label("You already have a UserName :-  " + PlayerPrefs.GetString("PlayerName"));
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Update LeaderBoard"))
                {
                    // add the score...
                    if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
                    if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");


                    dl.AddScore(PlayerPrefs.GetString("PlayerName"), PlayerPrefs.GetInt("HighScoreMeter"));
                    this.gs = gameState.leaderboard;
                }
                GUILayout.EndHorizontal();
            }
        }

        if (this.gs == gameState.leaderboard)
        {
            GUILayout.Label("High Scores: Marathon Master : ");
            List<DreamloLeaderBoard2.Score> scoreList = dl.ToListHighToLow();   //2

            if (scoreList == null)
            {
                GUILayout.Label("(loading...)");
            }
            else
            {
                int maxToDisplay = 50;
                int count = 0;
                foreach (DreamloLeaderBoard2.Score currentScore in scoreList)
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

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }



}

