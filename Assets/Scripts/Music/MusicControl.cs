using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{
    AudioSource[] audiosource;
    //AudioLowPassFilter lowpass;
    //AudioHighPassFilter highpass;
    public GCscrew gCscrew;
    //int startHighCutoff;
    //float lerpT = 0.0f;
    public int currentSong;
    //public OptionsSet options;
    
    public OptionsSet optionsSet;

    public void OnEnable()
    {
        currentSong = Random.Range(0, 2);
        Debug.Log("enable---"+ currentSong);
    }

    void Start ()
    {
        currentSong = Random.Range(0, 2);
        audiosource = GetComponents<AudioSource>();
        /*
        if (options.setEffects)
        {
            lowpass = GetComponent<AudioLowPassFilter>();
            highpass = GetComponent<AudioHighPassFilter>();
        }
        */
        optionsSet = FindObjectOfType<OptionsSet>();
	}
	
	void Update ()
    {
        /*
        if (options.setEffects)
        {
            lowpass.enabled = true;
            highpass.enabled = true;

            if (gCscrew.bonusFill <= 70)
            {
                highpass.cutoffFrequency = Mathf.MoveTowards(highpass.cutoffFrequency, 100, 2000 * Time.deltaTime);
                //highpass.cutoff = Mathf.Lerp(highpass.cutoff, 100, lerpT);
                //lerpT += 0.01f * Time.deltaTime;
            }
            else if (gCscrew.bonusFill <= 80)
            {
                highpass.cutoffFrequency = Mathf.MoveTowards(highpass.cutoffFrequency, 1000, 400 * Time.deltaTime);
            }
            else if (gCscrew.bonusFill <= 90)
            {
                highpass.cutoffFrequency = Mathf.MoveTowards(highpass.cutoffFrequency, 2000, 400 * Time.deltaTime);
            }
            if (gCscrew.bonus == 0)
            {
                lowpass.cutoffFrequency = Mathf.MoveTowards(lowpass.cutoffFrequency, 1000, 10000 * Time.deltaTime);
            }
            else
            {
                lowpass.cutoffFrequency = Mathf.MoveTowards(lowpass.cutoffFrequency, 20000, 10000 * Time.deltaTime);
            }
        }
        */
        if(optionsSet==null)
        {
            optionsSet = FindObjectOfType<OptionsSet>();
        }
        audiosource[0].enabled = optionsSet.setMusic;
        audiosource[1].enabled = optionsSet.setMusic;
        MusicChange();
    }

    void MusicChange()
    {
        if(!audiosource[currentSong].isPlaying)
        {
            if (0 == currentSong)
            {
                currentSong = 1;
                audiosource[currentSong].Play();
            }
            else
            {
                currentSong = 0;
                audiosource[currentSong].Play();
            }
            
        }
    }
}

