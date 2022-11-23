using UnityEngine;
using System.Collections;

public class ButtonSoundScript : MonoBehaviour
{
    bool on;
    AudioSource sound;
    public OptionsSet optionSet;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        on = optionSet.setSounds;
    }

    void Update()
    {
        sound.enabled = optionSet.setSounds;
        /*
        if(on!=optionSet.setSounds)
        {
            if(optionSet.setSounds)
            {
                sound.enabled = true;
            }
            else
            {
                sound.enabled = false;
            }
            on = optionSet.setSounds;
        }
        */
    }
}
