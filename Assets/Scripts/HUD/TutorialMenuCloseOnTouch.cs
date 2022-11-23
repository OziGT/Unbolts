using UnityEngine;
using System.Collections;

public class TutorialMenuCloseOnTouch : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.touchCount>0)
        {
            gameObject.active = false;
        }
	}
}
