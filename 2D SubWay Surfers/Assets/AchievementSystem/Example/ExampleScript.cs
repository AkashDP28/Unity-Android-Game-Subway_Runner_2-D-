using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example Code Only
/// </summary>
public class ExampleScript : MonoBehaviour
{
    public void Add1 (string Name)
    {
        AchievementManager.instance.AddAchievementProgress(Name, 1);
    }
    public void Add5(string Name)
    {
        AchievementManager.instance.AddAchievementProgress(Name, 5);
    }
    public void Add10(string Name)
    {
        AchievementManager.instance.AddAchievementProgress(Name, 10);
    }
    public void Add100(string Name)
    {
        AchievementManager.instance.AddAchievementProgress(Name, 100);
    }
}
