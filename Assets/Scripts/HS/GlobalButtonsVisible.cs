using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalButtonsVisible : MonoBehaviour
{
    Image image;
    Text text;
    public Transition HSmode;
	// Use this for initialization
	void Start ()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        image.enabled = HSmode.buttonsVisible;
        text.enabled = HSmode.buttonsVisible;
	}
}
