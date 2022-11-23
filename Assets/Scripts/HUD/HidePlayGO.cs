using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HidePlayGO : MonoBehaviour
{
    Image image;
    public GCscrew gCscrew;
    bool show=true;
	void Start ()
    {
        image = GetComponent<Image>();
	}
	
	void Update ()
    {
	    if(gCscrew.lost)
        {
            image.enabled = false;
        }
	}
    public void EnableImage()
    {
        image.enabled = true;
    }
}
