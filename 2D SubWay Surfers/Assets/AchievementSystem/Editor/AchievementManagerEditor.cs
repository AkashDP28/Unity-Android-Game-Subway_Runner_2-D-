using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CustomEditorTools;

[CustomEditor(typeof(AchievementManager))]
public class AchievementManagerEditor : Editor
{
    AchievementManager MyTarget;            //Reference to selected object
    int SelectedTab;                        //Tab that is currently active

    #region Styles
        GUIStyle ManageBackground = new GUIStyle();
        GUIStyle Border = new GUIStyle();
        GUIStyle ManageInsideBackground = new GUIStyle();
        GUIStyle RowButton = new GUIStyle();
        GUIStyle ProgressBar = new GUIStyle();
    #endregion

    List<bool> Hidden = new List<bool>();   //If each achievement in the list is hidden
    bool HideAll = true;                    //Button click to hide or show all                

    void OnApplicationQuit()
    {
        MyTarget.LoadAchievementState();
    }

    void OnEnable()
    {
        MyTarget = (AchievementManager) target;
        MyTarget.LoadAchievementState();

        for(int i = 0; i < MyTarget.AchievementList.Count; i ++)
        {
            Hidden.Add(false);
        }

        #region Editor Styles
            ManageBackground.normal.background = CET.MakeEditorBackgroundColor(new Color(0.805f, 0.805f, 0.813f));
            ManageBackground.padding = new RectOffset(5, 5, 5, 5);

            ManageInsideBackground.normal.background = CET.MakeEditorBackgroundColor(new Color(0.629f, 0.633f, 0.649f));
            ManageInsideBackground.padding = new RectOffset(0, 0, 5, 5);

            RowButton.padding = new RectOffset();
            RowButton.fixedHeight = 20;
            RowButton.fixedWidth = 20;
            RowButton.margin = new RectOffset(0, 5, 0, 0);

            ProgressBar.normal.background = CET.MakeEditorBackgroundColor(Color.blue);
            ProgressBar.margin = new RectOffset(0, 5, 0, 0);

            Border.normal.background = CET.MakeEditorBackgroundColor(new Color(0.2f, 0.2f, 0.2f));
            Border.padding = new RectOffset(3, 3, 3, 3);
            Border.margin = new RectOffset(0, 0, 0, 10);
        #endregion
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.Space(10);
        SelectedTab = GUILayout.Toolbar(SelectedTab, new string[] { "Settings", "Achievement List" });
        GUILayout.Space(10);

        switch (SelectedTab)
        {
            case 0:
                DrawSettings();
                break;
            case 1:
                DrawAchievementList();
                break;
        }
        serializedObject.ApplyModifiedProperties();
    }

    public void DrawAchievementList ()
    {
        if(GUILayout.Button(HideAll ? "Hide All" : "Open All", GUILayout.Width(70)))
        {
            for(int i = 0; i < Hidden.Count; i++)
            {
                Hidden[i] = HideAll;
            }
            HideAll = !HideAll;
        }

        for (int i = 0; i < MyTarget.AchievementList.Count; i++)
        {
            GUILayout.BeginVertical(Border);
            GUILayout.BeginVertical(ManageBackground);
            GUILayout.BeginHorizontal(ManageInsideBackground);
            
            if (GUILayout.Button(CET.LoadImageFromFile("Assets/AchievementSystem/Resources/" + (Hidden[i] ? "Plus.png" : "Minus.png")), RowButton))
            {
                Hidden[i] = !Hidden[i];
            }

            GUILayout.Label("(" + i + ") " + MyTarget.AchievementList[i].DisplayName);

            if (i > 0 && GUILayout.Button(CET.LoadImageFromFile("Assets/AchievementSystem/Resources/Up.png"), RowButton))
            {
                AchievementInfromation temp = MyTarget.AchievementList[i];
                MyTarget.AchievementList[i] = MyTarget.AchievementList[i - 1];
                MyTarget.AchievementList[i - 1] = temp;

                AchievementState temp2 = MyTarget.States[i];
                MyTarget.States[i] = MyTarget.States[i - 1];
                MyTarget.States[i - 1] = temp2;
                MyTarget.SaveAchievementState();

            }
            if (i < MyTarget.AchievementList.Count -1 && GUILayout.Button(CET.LoadImageFromFile("Assets/AchievementSystem/Resources/Down.png"), RowButton))
            {
                AchievementInfromation temp = MyTarget.AchievementList[i];
                MyTarget.AchievementList[i] = MyTarget.AchievementList[i + 1];
                MyTarget.AchievementList[i + 1] = temp;

                AchievementState temp2 = MyTarget.States[i];
                MyTarget.States[i] = MyTarget.States[i + 1];
                MyTarget.States[i + 1] = temp2;
                MyTarget.SaveAchievementState();
            }
            if (GUILayout.Button(CET.LoadImageFromFile("Assets/AchievementSystem/Resources/Cross.png"), RowButton))
            {
                MyTarget.AchievementList.RemoveAt(i);
                Hidden.RemoveAt(i);
                MyTarget.States.RemoveAt(i);
                MyTarget.SaveAchievementState();
                Repaint();
                return;
            }

            GUILayout.EndHorizontal();

            if(!Hidden[i])
            { 
                GUILayout.Space(10);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("Key"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("DisplayName"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("Description"));

                GUILayout.Space(10);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("LockedIcon"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("LockOverlay"));
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("AchievedIcon"));
                GUILayout.Space(10);
         
                EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("Spoiler"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("Progression"));

                if (MyTarget.AchievementList[i].Progression == true)
                {
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("ProgressGoal"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("AchievementList").GetArrayElementAtIndex(i).FindPropertyRelative("NotificationFrequency"));
                }
            }
            GUILayout.EndVertical();
            GUILayout.EndVertical();
        }

        GUILayout.Space(20);

        if (GUILayout.Button("Add"))
        {
            MyTarget.AchievementList.Add(new AchievementInfromation());
            MyTarget.States.Add(new AchievementState());
            MyTarget.SaveAchievementState();
            Hidden.Add(false);
        }
    }

    public void DrawSettings()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("DisplayTime"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NumberOnScreen"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("DisplayAchievements"));
        if(MyTarget.DisplayAchievements)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("StackLocation"));
        }
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ShowExactProgress"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("AutoSave")); 
        EditorGUILayout.PropertyField(serializedObject.FindProperty("AutoLoad"));

        CET.HorizontalLine();

        GUILayout.BeginVertical(ManageBackground);
        for (int i = 0; i < MyTarget.AchievementList.Count; i++)
        {
            Rect ProgressBarRect;
            Rect r = EditorGUILayout.BeginHorizontal(ManageInsideBackground);

            GUILayout.Label("[" + i + "] " + MyTarget.AchievementList[i].DisplayName + " (" + MyTarget.AchievementList[i].Key + ")", GUILayout.Width(250));

            if (MyTarget.AchievementList[i].Progression)
            {
                float Progress = MyTarget.States[i].Progress / MyTarget.AchievementList[i].ProgressGoal;
                ProgressBarRect = EditorGUILayout.BeginHorizontal(ProgressBar, GUILayout.ExpandWidth(true));
                GUILayout.Label("");
                EditorGUILayout.EndHorizontal();
                EditorGUI.ProgressBar(ProgressBarRect, Progress, "" + MyTarget.States[i].Progress + " / " + MyTarget.AchievementList[i].ProgressGoal + " (" + (Progress * 100) + "%)");
            }
            else
            {
                GUILayout.Label(MyTarget.States[i].Achieved ? "True" : "False");
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(2);
        }
        GUILayout.EndVertical();
        CET.HorizontalLine();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Save States"))
        {
            MyTarget.SaveAchievementState();
        }
        if (GUILayout.Button("Reset States"))
        {
            MyTarget.ResetAchievementState();
        }
        if (!MyTarget.AutoLoad && GUILayout.Button("Load States"))
        {
            MyTarget.LoadAchievementState();
        }
        GUILayout.EndHorizontal();
        CET.HorizontalLine();
        GUILayout.Space(20);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Stack"));
    }
}