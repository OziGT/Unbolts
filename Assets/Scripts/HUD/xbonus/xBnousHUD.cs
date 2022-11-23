using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class xBnousHUD : MonoBehaviour
{
    Image image;
    public int type;
    public xBonus xbonus;
    public GCscrew gCscrew;
	void Start ()
    {
        image = GetComponent<Image>();
       // canvas = GetComponent<RectTransform>();
        image.enabled = false;
	}
	
	void Update ()
    {
	    if(type==xbonus.xbonus)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
            
        }
        
	}
}
