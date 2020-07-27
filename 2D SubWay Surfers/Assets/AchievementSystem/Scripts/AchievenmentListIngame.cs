using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Add list of achievements to screen
/// </summary>
public class AchievenmentListIngame : MonoBehaviour
{
    [HideInInspector] public GameObject scrollContent;
    [HideInInspector] public GameObject prefab;
    [HideInInspector] public GameObject Menu;
    [HideInInspector] public Dropdown Filter;
    [HideInInspector] public Text CountText;
    [HideInInspector] public Text CompleteText;
    [HideInInspector] public Scrollbar Scrollbar;

    private bool MenuOpen = false;  //Is the in-game UI open
    public KeyCode OpenMenuKey;     //Key to open in-game menu

    
    /// <summary>
    /// Adds all achievements to the UI based on a filter
    /// </summary>
    /// <param name="Filter">Filter to use (All, Achieved or Unachieved)</param>
    /// 


    public static AchievenmentListIngame instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void AddAchievements(string Filter)
    {  
        foreach (Transform child in scrollContent.transform)
        {
            Destroy(child.gameObject);
        }
        AchievementManager AM = AchievementManager.instance;
        int AchievedCount = AM.GetAchievedCount();

        CountText.text = "" + AchievedCount + " / " + AM.States.Count;
        CompleteText.text = "Complete (" + AM.GetAchievedPercentage() + "%)";

        for (int i = 0; i < AM.AchievementList.Count; i ++)
        {
            if(!AM.AchievementList[i].Spoiler || AM.States[i].Achieved)
            {
                if((Filter.Equals("All")) || (Filter.Equals("Achieved") && AM.States[i].Achieved) || (Filter.Equals("Unachieved") && !AM.States[i].Achieved))
                {
                    UIAchievement Achievement = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity).GetComponent<UIAchievement>();
                    Achievement.Set(AM.AchievementList[i], AM.States[i]);
                    Achievement.transform.SetParent(scrollContent.transform);
                }
            }
        }
        Scrollbar.value = 1;
    }

    /// <summary>
    /// Filter out a set of locked or unlocked achievements
    /// </summary>
    public void ChangeFilter ()
    {
        AddAchievements(Filter.options[Filter.value].text);
    }

    private void Update()
    {
        if(Input.GetKeyDown(OpenMenuKey))
        {
            MenuOpen = !MenuOpen;
            Menu.SetActive(MenuOpen);
            if(MenuOpen)
            {
                AddAchievements("All");
            }
        }
    }

    public void AchievementViewer()
    {
        MenuOpen = !MenuOpen;
        Menu.SetActive(MenuOpen);
        if (MenuOpen)
        {
            AddAchievements("All");
            MenuController.IsAchievement = true;
        }
        if (!MenuOpen)
        {
            MenuController.IsAchievement = false;
        }
        MenuController.instance.AchievementPanel.SetActive(MenuOpen);
    }
}