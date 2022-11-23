using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuEnabler : MonoBehaviour
{
    public bool button;
    PauseMenuMovement parent;
    Image image;

	void Start ()
    {
        parent = GetComponentInParent<PauseMenuMovement>();
        image = GetComponent<Image>();
	}
	
	void Update ()
    {
	    if(parent.onMove)
        {
            if(button)
            {   
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
            }
        }
        else
        {
            if (!button)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
            }
        }
	}
}
