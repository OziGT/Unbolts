using UnityEngine;
using UnityEngine.Advertisements;

public class VideoAds : MonoBehaviour
{
    HSFile hsController;
    public GameObject informationButton, success;
    public Transition transition;
    public AdOnceADay adOnceADay;
    public void ShowRewardedAd()
    { 
        
        if (Advertisement.IsReady("rewardedVideo"))
        {
            hsController = GetComponent<HSFile>();
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                hsController.SubmitHS();
                adOnceADay.UpdateDate();
                success.SetActive(true);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
        informationButton.active = false;
    }
}