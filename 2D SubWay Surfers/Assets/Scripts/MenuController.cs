using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text CoinText;
    public Text CurrentCoinText;
    public Text CurrentMeterText;

    public Text HighScoreCoinText;
    public Text HighScoreMeterText;

    public GameObject AchievementPanel;

    public static MenuController instance;

    public Text AchievementText;
    public static bool IsAchievement;

    public GameObject DailyReward;
    [HideInInspector]
    public bool DailyOpen;
    public GameObject Canvas;

    public GameObject ShopPanel;
    public Button BuyRedButton, BuyBlueButton;
    public Text YouHaveRedText, YouHaveBlueText;

    public GameObject LBpanel;
    public GameObject LB,LB2;

    public GameObject AchievementButton, DailyRewardButton, ShopButton, LeaderBoardButton,SoundButton,CreditButton;
    public GameObject MenuP, CoinP, HighCoinP;

    public GameObject CreditsPanel;

    public GameObject AdLoadingPanel;
    [HideInInspector]
    public bool AdLoadPanelOpenKro;
    [HideInInspector]
    public bool PoorNetTextOpenKro;
    public GameObject PoorNetText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        //lb
        LB.SetActive(false);
        LB2.SetActive(false);
        //
        if (PlayerPrefs.HasKey("CoinTotal"))
        {
            PlayerPrefs.SetInt("CoinTotal", PlayerPrefs.GetInt("CoinTotal") + PlayerPrefs.GetInt("CoinRun"));
        }
        else
        {
            PlayerPrefs.SetInt("CoinTotal", PlayerPrefs.GetInt("CoinRun"));
        }
     //   CoinText.text = PlayerPrefs.GetInt("CoinTotal").ToString();

        //Achievement

        //Chillar
        if (PlayerPrefs.GetInt("CoinTotal") > 1000)
        {
            AchievementManager.instance.SetAchievementProgress("CW", 1000);
        }
        else
        {
            AchievementManager.instance.SetAchievementProgress("CW", PlayerPrefs.GetInt("CoinTotal"));
        }
        //Gullak
        if (PlayerPrefs.GetInt("CoinTotal") > 10000)
        {
            AchievementManager.instance.SetAchievementProgress("GW", 10000);
        }
        else
        {
            AchievementManager.instance.SetAchievementProgress("GW", PlayerPrefs.GetInt("CoinTotal"));
        }
        //Bank
        if (PlayerPrefs.GetInt("CoinTotal") > 100000)
        {
            AchievementManager.instance.SetAchievementProgress("BW", 100000);
        }
        else
        {
            AchievementManager.instance.SetAchievementProgress("BW", PlayerPrefs.GetInt("CoinTotal"));
        }
        //Tresure
        if (PlayerPrefs.GetInt("CoinTotal") > 1000000)
        {
            AchievementManager.instance.SetAchievementProgress("T", 1000000);
        }
        else
        {
            AchievementManager.instance.SetAchievementProgress("T", PlayerPrefs.GetInt("CoinTotal"));
        }
        // AchievementManager.instance.SetAchievementProgress("CW", PlayerPrefs.GetInt("CoinTotal"));
       // AchievementManager.instance.SetAchievementProgress("GW", PlayerPrefs.GetInt("CoinTotal"));
       // AchievementManager.instance.SetAchievementProgress("BW", PlayerPrefs.GetInt("CoinTotal"));
       // AchievementManager.instance.SetAchievementProgress("T", PlayerPrefs.GetInt("CoinTotal"));

    }
    public void Update()
    {
        if (IsAchievement)
        {
            AchievementText.text = "Close";
        }
        if (!IsAchievement)
        {
            AchievementText.text = "Achievements";
        }
        //current_coin
        /* if (PlayerPrefs.HasKey("CoinCurrent"))
         {
             PlayerPrefs.SetInt("CoinCurrent", PlayerPrefs.GetInt("CoinRun"));
         }
         else
         {
             PlayerPrefs.SetInt("CoinCurrent", 0);
         }*/
        CurrentCoinText.text = PlayerPrefs.GetInt("CoinRun").ToString();
        CurrentMeterText.text = PlayerPrefs.GetInt("CurrentMeter").ToString();
        HighScore();

        //Button Interaction
        if (PlayerPrefs.GetInt("CoinTotal") > 1000)
        {
            BuyRedButton.interactable = true;
        }
        else
        {
            BuyRedButton.interactable = false;
        }
        if (PlayerPrefs.GetInt("CoinTotal") > 2000)
        {
            BuyBlueButton.interactable = true;
        }
        else
        {
            BuyBlueButton.interactable = false;
        }
        //CoinText
        CoinText.text = PlayerPrefs.GetInt("CoinTotal").ToString();
        //youHaveText
        YouHaveRedText.text = "You Have : x " + PlayerPrefs.GetInt("RedNumber");
        YouHaveBlueText.text = "You Have : x " + PlayerPrefs.GetInt("BlueNumber");

        //AdloadingPAnel
        if (AdLoadPanelOpenKro)
        {
            AdLoadingPanel.SetActive(true);
        }
        else
        {
            AdLoadingPanel.SetActive(false);
        }
        //Poornettext
        if (PoorNetTextOpenKro)
        {
            Debug.Log("AAAAAAAAAAAA");
            PoorNetText.SetActive(true);
            StartCoroutine(DeactivatePoorNetText());
           
        }
    }

    IEnumerator DeactivatePoorNetText()
    {
        yield return new WaitForSeconds(2f);
        PoorNetText.SetActive(false);
        Debug.Log("BBBBBBBBBBBBBB");
        PoorNetTextOpenKro = false;
    }
    void HighScore()
    {
        //coin
        if (PlayerPrefs.HasKey("HighScoreCoin"))
        {
            if (PlayerPrefs.GetInt("CoinRun") > PlayerPrefs.GetInt("HighScoreCoin"))
            {
                PlayerPrefs.SetInt("HighScoreCoin", PlayerPrefs.GetInt("CoinRun"));
            }
            else
            {
                PlayerPrefs.SetInt("HighScoreCoin", PlayerPrefs.GetInt("HighScoreCoin"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScoreCoin", 0);
        }

        HighScoreCoinText.text = PlayerPrefs.GetInt("HighScoreCoin").ToString();

        //meter
        if (PlayerPrefs.HasKey("HighScoreMeter"))
        {
            if (PlayerPrefs.GetInt("CurrentMeter") > PlayerPrefs.GetInt("HighScoreMeter"))
            {
                PlayerPrefs.SetInt("HighScoreMeter",PlayerPrefs.GetInt("CurrentMeter"));
            }
            else
            {
                PlayerPrefs.SetInt("HighScoreMeter", PlayerPrefs.GetInt("HighScoreMeter"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScoreMeter", 0);
        }

        HighScoreMeterText.text = PlayerPrefs.GetInt("HighScoreMeter").ToString();
        AchievementManager.instance.SetAchievementProgress("Bo", PlayerPrefs.GetInt("HighScoreMeter"));
        AchievementManager.instance.SetAchievementProgress("Mik", PlayerPrefs.GetInt("HighScoreMeter"));
        AchievementManager.instance.SetAchievementProgress("Che", PlayerPrefs.GetInt("HighScoreMeter"));
        AchievementManager.instance.SetAchievementProgress("WU", PlayerPrefs.GetInt("HighScoreMeter"));
        AchievementManager.instance.SetAchievementProgress("Dha", PlayerPrefs.GetInt("HighScoreMeter"));
    }
    public void PlayButton()
    {
        //  SceneManager.LoadScene("GamePlay");
        LevelLoader.instance.LoadLevel(1);
        GameManager.instance.IsPlayerDead = false;
        SoundManagerMainMenu.instance.ButtonSoundPlay();
    }

    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Achievement()
    {
        AchievenmentListIngame.instance.AchievementViewer();

        DailyRewardButton.SetActive(!IsAchievement);
        ShopButton.SetActive(!IsAchievement);
        LeaderBoardButton.SetActive(!IsAchievement);
        MenuP.SetActive(!IsAchievement);
        CoinP.SetActive(!IsAchievement);
        HighCoinP.SetActive(!IsAchievement);
        SoundButton.SetActive(!IsAchievement);
        CreditButton.SetActive(!IsAchievement);
        SoundManagerMainMenu.instance.ButtonSoundPlay();
        ADManager.instance.DisplayInterstitialAfterSomeTime();
        ADManager.instance.DisplayRewardedAfterSomeTime();
    }

    public void Quit()
    {
        //   Application.Quit();
        // Debug.Log("Exit");
        ADManager.instance.Display_Banner();
        ADManager.instance.DisplayInterstitialAfterSomeTime();
        ADManager.instance.DisplayRewardedAfterSomeTime();
    }

    public void Daily()
    {
        // DailyOpen = !DailyOpen;
        //   DailyReward.SetActive(DailyOpen);
        DailyReward.SetActive(true);
        Canvas.SetActive(true);
        SoundManagerMainMenu.instance.ButtonSoundPlay();
        ADManager.instance.DisplayInterstitialAfterSomeTime();
        ADManager.instance.DisplayRewardedAfterSomeTime();

    }

    public void ShopClicked()
    {
        ShopPanel.SetActive(true);
        AchievementButton.SetActive(false);
        DailyRewardButton.SetActive(false);
        LeaderBoardButton.SetActive(false);
        SoundButton.SetActive(false);
        CreditButton.SetActive(false);

        MenuP.SetActive(false);
        CoinP.SetActive(false);
        HighCoinP.SetActive(false);
        SoundManagerMainMenu.instance.ButtonSoundPlay();
      //  ADManager.instance.Display_Banner();
        ADManager.instance.DisplayInterstitialAfterSomeTime();
        ADManager.instance.DisplayRewardedAfterSomeTime();
    }

    public void ShopCut()
    {
        ShopPanel.SetActive(false);

        AchievementButton.SetActive(true);
        DailyRewardButton.SetActive(true);
        LeaderBoardButton.SetActive(true);
        SoundButton.SetActive(true);
        CreditButton.SetActive(true);

        MenuP.SetActive(true);
        CoinP.SetActive(true);
        HighCoinP.SetActive(true);
        SoundManagerMainMenu.instance.ButtonSoundPlay();
     //   ADManager.instance.StopBannerAd();
    }

    public void BuyRedClicked()
    {
        PlayerPrefs.SetInt("CoinTotal", PlayerPrefs.GetInt("CoinTotal") - 1000);
        PlayerPrefs.SetInt("RedNumber", PlayerPrefs.GetInt("RedNumber") + 1);
        SoundManagerMainMenu.instance.ButtonSoundPlay();

        ADManager.instance.Display_Interstitial();
    }
    
    public void BuyBlueClicked()
    {
        PlayerPrefs.SetInt("CoinTotal", PlayerPrefs.GetInt("CoinTotal") - 2000);
        PlayerPrefs.SetInt("BlueNumber", PlayerPrefs.GetInt("BlueNumber") + 1);
        SoundManagerMainMenu.instance.ButtonSoundPlay();

        ADManager.instance.Display_Interstitial();
    }

    public void LBbuttonClicked()
    {
        LBpanel.SetActive(true);
        LB.SetActive(true);
        LB2.SetActive(true);

        AchievementButton.SetActive(false);
        DailyRewardButton.SetActive(false);
        ShopButton.SetActive(false);
        LeaderBoardButton.SetActive(false);
        SoundButton.SetActive(false);
        CreditButton.SetActive(false);

        MenuP.SetActive(false);
        CoinP.SetActive(false);
        HighCoinP.SetActive(false);
        SoundManagerMainMenu.instance.ButtonSoundPlay();
        ADManager.instance.DisplayInterstitialAfterSomeTime();
        ADManager.instance.DisplayRewardedAfterSomeTime();
    }

    public void cutLBpanel()
    {
        LBpanel.SetActive(false);
        LB.SetActive(false);
        LB2.SetActive(false);

        AchievementButton.SetActive(true);
        DailyRewardButton.SetActive(true);
        ShopButton.SetActive(true);
        LeaderBoardButton.SetActive(true);
        SoundButton.SetActive(true);
        CreditButton.SetActive(true);

        MenuP.SetActive(true);
        CoinP.SetActive(true);
        HighCoinP.SetActive(true);
        SoundManagerMainMenu.instance.ButtonSoundPlay();
    }

    public void WatchVideo()
    {
        SoundManagerMainMenu.instance.ButtonSoundPlay();
        // AdManager.Instance.ShowRewardedVideo();
        //GoogleAds.instance.UserOptToWatchAd();
        // ADManager.instance.Display__RewardedVideo();
        ADManager.instance.Display_RewardedVideo_UsingCoroutine();
    }

    public void OpenCreditsPanel()
    {
        SoundManagerMainMenu.instance.ButtonSoundPlay();
        CreditsPanel.SetActive(true);
        ADManager.instance.DisplayInterstitialAfterSomeTime();
        ADManager.instance.DisplayRewardedAfterSomeTime();
       // ADManager.instance.Display_Banner();

        AchievementButton.SetActive(false);
        DailyRewardButton.SetActive(false);
        ShopButton.SetActive(false);
        LeaderBoardButton.SetActive(false);
        SoundButton.SetActive(false);
        CreditButton.SetActive(false);
    }

    public void CloseCreditsPanel()
    {
        SoundManagerMainMenu.instance.ButtonSoundPlay();
        CreditsPanel.SetActive(false);
       // ADManager.instance.StopBannerAd();

        AchievementButton.SetActive(true);
        DailyRewardButton.SetActive(true);
        ShopButton.SetActive(true);
        LeaderBoardButton.SetActive(true);
        SoundButton.SetActive(true);
        CreditButton.SetActive(true);
    }
}//end
