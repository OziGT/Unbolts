using UnityEngine;
using System.Collections;

public class SubmitButtonEnabler : MonoBehaviour {

    public GameObject submit;
    public GameObject submitAd;
    AdOnceADay adOnceADay;
	void Start ()
    {
        adOnceADay = GetComponent<AdOnceADay>();
	}
	
	
	void Update ()
    {
            submitAd.SetActive(adOnceADay.play);
            submit.SetActive(!adOnceADay.play);
	}
}
