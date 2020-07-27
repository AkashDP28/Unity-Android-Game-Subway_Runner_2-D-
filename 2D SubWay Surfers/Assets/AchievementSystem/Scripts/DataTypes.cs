using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Storesinformation related to a single achievement
/// </summary>
[System.Serializable]
public struct AchievementInfromation
{
    [SerializeField] public string Key;                     //Name used to unlock achievement
    [SerializeField] public string DisplayName;             //Display name for achievement
    [SerializeField] public string Description;             //Display description for achievement
    [SerializeField] public Sprite LockedIcon;              //Display icon for achievement when not achieved
    [SerializeField] public bool LockOverlay;               //Use lock icon as overlay
    [SerializeField] public Sprite AchievedIcon;            //Display icon for achievement when achieved
    [SerializeField] public bool Spoiler;                   //Hide from player until unlocked
    [SerializeField] public bool Progression;               //Should this be a progression achievement e.g. Collect 4/10 items or do 1000 damage
    [SerializeField] public float ProgressGoal;             //The progress goal to reach
    [SerializeField] public float NotificationFrequency;    //How offen should the user be shown progress notifications
}

/// <summary>
/// Stores the current progress and achieved state
/// </summary>
[System.Serializable]
public class AchievementState
{
    public AchievementState(float NewProgress, bool NewAchieved)
    {
        Progress = NewProgress;
        Achieved = NewAchieved;
    }
    public AchievementState() { }

    [SerializeField] public float Progress;             //Progress towards goal
    [SerializeField] public int LastProgressUpdate = 0; //Last achievement notification bracket
    [SerializeField] public bool Achieved = false;      //Is the achievement unlocked
}

/// <summary>
/// Place where an achievement will be displayed on the screen
/// </summary>
public enum AchievementStackLocation
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}