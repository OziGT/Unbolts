using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xBnousHUDbackground : MonoBehaviour
{
    Image image;
    public GCscrew gCscrew;
	void Start ()
    {
        image = GetComponent<Image>();
        image.enabled = false;
	}
	
	void Update ()
    {
	    if(0<gCscrew.xBonus)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
	}
}
