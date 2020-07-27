using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
public class ADManager : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-6914027797047146~5961072497";

    private BannerView bannerView;
    private InterstitialAd interstitialView;
    private RewardBasedVideoAd rewardedView;

    public static ADManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        MobileAds.Initialize(initStatus => { }); //change it
        RequestBanner();
        RequestInterstitial();
        RequestVideoAD();

        //Events

        //Banner
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

        //Interstitial
        // Called when an ad request has successfully loaded.
        this.interstitialView.OnAdLoaded += HandleOnAdLoaded_I;
        // Called when an ad request failed to load.
        this.interstitialView.OnAdFailedToLoad += HandleOnAdFailedToLoad_I;
        // Called when an ad is shown.
        this.interstitialView.OnAdOpening += HandleOnAdOpened_I;
        // Called when the ad is closed.
        this.interstitialView.OnAdClosed += HandleOnAdClosed_I;
        // Called when the ad click caused the user to leave the application.
        this.interstitialView.OnAdLeavingApplication += HandleOnAdLeavingApplication_I;

        //Rewarded
        // Called when an ad request has successfully loaded.
        rewardedView.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardedView.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardedView.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardedView.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardedView.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardedView.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardedView.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
    }

    void RequestBanner()
    {
        string banner_ID = "ca-app-pub-6914027797047146/4264847440";//Change ii
        bannerView = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Bottom);

        //ForTesting
       // AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build(); //Change it
                                                                                                                 //for Publishing
        AdRequest adRequest = new AdRequest.Builder().Build();

        bannerView.LoadAd(adRequest);
    }

    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-6914027797047146/1694524427";//Change ii
        interstitialView = new InterstitialAd(interstitial_ID);

        //ForTesting
       // AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build(); //Change it
                                                                                                                 //for Publishing
        AdRequest adRequest = new AdRequest.Builder().Build();

        interstitialView.LoadAd(adRequest);
    }

    void RequestVideoAD()
    {
        string Video_ID = "ca-app-pub-6914027797047146/2568622396";//Change ii
        rewardedView = RewardBasedVideoAd.Instance;

        //ForTesting
      //  AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build(); //Change it
                                                                                                                 //for Publishing
        AdRequest adRequest = new AdRequest.Builder().Build();

        rewardedView.LoadAd(adRequest, Video_ID);
    }

    public void Display_Banner()
    {
        bannerView.Show();
    }

    public void Display_Interstitial()
    {
        if (interstitialView.IsLoaded())
        {
            interstitialView.Show();
        }
    }

    public void Display__RewardedVideo()
    {
        if (rewardedView.IsLoaded())
        {
            rewardedView.Show();
        }
    }

    public void Display_RewardedVideo_UsingCoroutine()
    {
        StartCoroutine(ShowRewardedAd_usingCoroutine());
    }

    IEnumerator ShowRewardedAd_usingCoroutine()
    {
        RequestVideoAD();
        while (!rewardedView.IsLoaded())
        Debug.Log("Currently Loading rewarded Ad");
        MenuController.instance.AdLoadPanelOpenKro = true;
        yield return new WaitForSeconds(5f);

        if (rewardedView.IsLoaded())
        {
            rewardedView.Show();
            MenuController.instance.AdLoadPanelOpenKro = false;
           // MenuController.instance.PoorNetTextOpenKro = true;
        }
        else
        {
            MenuController.instance.AdLoadPanelOpenKro = false;
            MenuController.instance.PoorNetTextOpenKro = true;
        }

    }

    public void StopBannerAd()
    {
        bannerView.Destroy();
    }

    public void DisplayInterstitialAfterSomeTime()
    {
        if (PlayerPrefs.HasKey("AdCount"))
        {
            if (PlayerPrefs.GetInt("AdCount") == 3)
            {
                //ShowAd
                if (interstitialView.IsLoaded())
                {
                    interstitialView.Show();
                }
                PlayerPrefs.SetInt("AdCount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("AdCount", PlayerPrefs.GetInt("AdCount") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdCount", 0);
        }
    }

    public void DisplayRewardedAfterSomeTime()
    {
        if (PlayerPrefs.HasKey("AdCountR"))
        {
            if (PlayerPrefs.GetInt("AdCountR") == 8)
            {
                //ShowAd
                if (rewardedView.IsLoaded())
                {
                    rewardedView.Show();
                }
                PlayerPrefs.SetInt("AdCountR", 0);
            }
            else
            {
                PlayerPrefs.SetInt("AdCountR", PlayerPrefs.GetInt("AdCountR") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdCountR", 0);
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
       // Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    //interstitial
    public void HandleOnAdLoaded_I(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad_I(object sender, AdFailedToLoadEventArgs args)
    {
        RequestInterstitial();
    }

    public void HandleOnAdOpened_I(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed_I(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication_I(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
   

    //rewarded
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestVideoAD();
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        PlayerPrefs.SetInt("CoinTotal", PlayerPrefs.GetInt("CoinTotal") + 2000);
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }
    //////aaaaaaaaaaaaaaaaaaaaaaaaaa
   /* void HandleBannerAdEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerView.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerView.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            this.bannerView.OnAdLoaded -= this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerView.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerView.OnAdOpening -= this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerView.OnAdClosed -= this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerView.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
        }
    }

    void HandleInterstitialAD(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            this.interstitialView.OnAdLoaded += HandleOnAdLoaded_I;
            // Called when an ad request failed to load.
            this.interstitialView.OnAdFailedToLoad += HandleOnAdFailedToLoad_I;
            // Called when an ad is shown.
            this.interstitialView.OnAdOpening += HandleOnAdOpened_I;
            // Called when the ad is closed.
            this.interstitialView.OnAdClosed += HandleOnAdClosed_I;
            // Called when the ad click caused the user to leave the application.
            this.interstitialView.OnAdLeavingApplication += HandleOnAdLeavingApplication_I;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            this.interstitialView.OnAdLoaded -= HandleOnAdLoaded_I;
            // Called when an ad request failed to load.
            this.interstitialView.OnAdFailedToLoad -= HandleOnAdFailedToLoad_I;
            // Called when an ad is shown.
            this.interstitialView.OnAdOpening -= HandleOnAdOpened_I;
            // Called when the ad is closed.
            this.interstitialView.OnAdClosed -= HandleOnAdClosed_I;
            // Called when the ad click caused the user to leave the application.
            this.interstitialView.OnAdLeavingApplication -= HandleOnAdLeavingApplication_I;
        }
    }
    //bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
    void HandleRewardedAd(bool subscribed)
    {
        if (subscribed)
        {
            // Called when an ad request has successfully loaded.
            rewardedView.OnAdLoaded += HandleRewardBasedVideoLoaded;
            // Called when an ad request failed to load.
            rewardedView.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
            // Called when an ad is shown.
            rewardedView.OnAdOpening += HandleRewardBasedVideoOpened;
            // Called when the ad starts to play.
            rewardedView.OnAdStarted += HandleRewardBasedVideoStarted;
            // Called when the user should be rewarded for watching a video.
            rewardedView.OnAdRewarded += HandleRewardBasedVideoRewarded;
            // Called when the ad is closed.
            rewardedView.OnAdClosed += HandleRewardBasedVideoClosed;
            // Called when the ad click caused the user to leave the application.
            rewardedView.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            rewardedView.OnAdLoaded -= HandleRewardBasedVideoLoaded;
            // Called when an ad request failed to load.
            rewardedView.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;
            // Called when an ad is shown.
            rewardedView.OnAdOpening -= HandleRewardBasedVideoOpened;
            // Called when the ad starts to play.
            rewardedView.OnAdStarted -= HandleRewardBasedVideoStarted;
            // Called when the user should be rewarded for watching a video.
            rewardedView.OnAdRewarded -= HandleRewardBasedVideoRewarded;
            // Called when the ad is closed.
            rewardedView.OnAdClosed -= HandleRewardBasedVideoClosed;
            // Called when the ad click caused the user to leave the application.
            rewardedView.OnAdLeavingApplication -= HandleRewardBasedVideoLeftApplication;
        }
    }

  /*  private void OnEnable()
    {
        HandleBannerAdEvents(true);
        HandleInterstitialAD(true);
        HandleRewardedAd(true);
       
    }*/

  /*  private void OnDisable()
    {
        HandleBannerAdEvents(false);
        HandleInterstitialAD(false);
        HandleRewardedAd(false);
    }*/
}
