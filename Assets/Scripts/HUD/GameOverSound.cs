using UnityEngine;
using System.Collections;

public class GameOverSound : MonoBehaviour
{
    public GCscrew gCscrew;
    AudioSource sound;
    bool played = true;
    public OptionsSet optionSet;
    bool on;
    void Start ()
    {
        sound = GetComponent<AudioSource>();
        on = optionSet.setSounds;
    }
	
	void Update ()
    {
        sound.enabled = optionSet.setSounds;
        if (gCscrew.lost && played)
        {
            sound.Play();
            played = false;
        }
	}
}
