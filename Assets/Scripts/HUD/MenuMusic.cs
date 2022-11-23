using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour
{
    bool on;
    AudioSource sound;
    public OptionsSet optionSet;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        on = optionSet.setMusic;
    }

    void Update()
    {

        sound.enabled = optionSet.setMusic;
    }
}
