using UnityEngine;
using System.Collections;
//using GoogleMobileAds.Api;


    public class AdManager : MonoBehaviour {

    public static AdManager Instance { set; get; }
    public string bannerId, videoId;
    //public BannerView bannerView;
    //public InterstitialAd interstitial;

    

    // Use this for initialization
    void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "Edit";
#elif UNITY_ANDROID
        string adUnitId = bannerId;
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the bottom of the screen.
        //bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        //bannerView.LoadAd(request);
        //bannerView.Hide();
    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = videoId;
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        //interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        //interstitial.LoadAd(request);
    }

    public void ShowVideo()
    {
        //if (interstitial.IsLoaded())
        //{
        //    interstitial.Show();
        //}
    }


    public void ShowBanner()
    {
        //bannerView.Show();
    }

    public void HideBanner()
    {
        //bannerView.Hide();
    }

    
}
