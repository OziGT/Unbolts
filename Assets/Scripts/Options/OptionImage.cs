using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionImage : MonoBehaviour
{
    Image image;
    public OptionsSet optionSet;
    public bool OK;
    public int optionID;

    void Start ()
    {
        image = GetComponent<Image>();
    }

    
	void Update ()
    {
        switch(optionID)
        {
            case 1:
                ChangeSounds();
                break;
            case 0:
                ChangeMusic();
                break;
            case 2:
                ChangeEffects();
                break;
        }
    }
    
    public void ChangeSounds()
    {
        if (OK)
        {
            image.enabled = optionSet.setSounds;
        }
        else
        {
            image.enabled = !optionSet.setSounds;
        }
    }
    public void ChangeMusic()
    {
        if (OK)
        {
            image.enabled = optionSet.setMusic;
        }
        else
        {
            image.enabled = !optionSet.setMusic;
        }
    }
    public void ChangeEffects()
    {
        if (OK)
        {
            image.enabled = optionSet.setEffects;
        }
        else
        {
            image.enabled = !optionSet.setEffects;
        }
    }
}
