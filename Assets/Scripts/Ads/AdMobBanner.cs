using System;
using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;


public class AdMobBanner : MonoBehaviour
{
    BannerView bannerView;
    public GameObject HS;
    bool hsActive;
    // Use this for initialization
    void Start()
    {
        hsActive = HS.active;
    }

    // Update is called once per frame
    void Update()
    {
        if (HS.active != hsActive)
        {
            if (HS.active == false)
            {
                bannerView.Show();
            }
            else
            {
                bannerView.Hide();
            }
            hsActive = HS.active;
        }

    }
    /*
    public void ShowBanner()
    {
        bannerView.Show();
    }
    */

    public void HideBanner()
    {
        bannerView.Hide();
    }
    public void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
                        string adUnitId = "ca-app-pub-9035565607629166/5673651648";
#elif UNITY_IPHONE
                        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
                        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopLeft);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("F512EB03B170B2AD8C296395080FE9FC").Build();
        // Load the banner with the request.



        bannerView.LoadAd(request);

        bannerView.Show();

        /*
        bannerView.OnAdLoaded += HandleAdLoaded;
        bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
        bannerView.OnAdOpening += HandleAdOpening;
        //bannerView.OnAdOpened += ... ; //Causes error: `GoogleMobileAds.Api.InterstitialAd' does not contain a definition for `OnAdOpened' and no extension method `OnAdOpened' of type `GoogleMobileAds.Api.InterstitialAd' could be found
        bannerView.OnAdClosed += HandleAdClosed;
        bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
        // Load a banner
        
        //bannerView.LoadAd(createAdRequest());
        */


    }
    /*
    public void HandleAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleAdLoaded event received.");
    }
    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpening(object sender, EventArgs args)
    {
        Debug.Log("HandleAdOpened event received");
    }


    public void HandleAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("HandleAdLeftApplication event received");
    }
    */
}
