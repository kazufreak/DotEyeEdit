using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour
{
    public static BannerView bannerView;
    AdRequest request;

    void Start()
    {
        
    }

    void Awake () {

        // アプリID、 
        string appId = "ca-app-pub-9746875704571459~3339900474";
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        DontDestroyOnLoad(this);
        RequestBanner();
    }

    private void RequestBanner()
    {

        // 広告ユニットID 
        string adUnitId = "ca-app-pub-9746875704571459/8509602148";
        

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
