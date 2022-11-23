using UnityEngine;
using System.Collections;

public class BonusUpDownSound : MonoBehaviour {

    public bool up;
    bool on;
    AudioSource sound;
    public OptionsSet optionSet;
    public GCscrew gCscrew;
    int currentBonus;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        on = optionSet.setSounds;
        currentBonus = gCscrew.bonus;
    }

    void Update()
    {
        sound.enabled = optionSet.setSounds;
        if(up && currentBonus<gCscrew.bonus)
        {
            sound.Play();
            

        }
        if (!up && currentBonus > gCscrew.bonus)
        {
            sound.Play();
            
        }
        if(currentBonus!=gCscrew.bonus)
        {
            currentBonus = gCscrew.bonus;
        }
    }
}
