using UnityEngine;
using System.Collections;

public class OptionsSetGlobal : MonoBehaviour
{
    public bool setSounds, setMusic;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSounds()
    {
        if (setSounds)
        {
            setSounds = false;
        }
        else
        {
            setSounds = true;
        }
    }
    public void ChangeMusc()
    {
        if (setMusic)
        {
            setMusic = false;
        }
        else
        {
            setMusic = true;
        }
    }
}
