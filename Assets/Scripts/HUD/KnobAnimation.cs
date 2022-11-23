using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KnobAnimation : MonoBehaviour
{
    Touch_Knob touch_knob;
    Transform transform;
    public GCscrew gCscrew;
    Image image;
	void Start ()
    {
        touch_knob = GetComponent<Touch_Knob>();
        transform = GetComponent<Transform>();
        image = GetComponent<Image>();
	}
	
	void Update ()
    {

        if (gCscrew.paused)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }
        //make invisible
	    if(!gCscrew.touchScreenTrue)
        {
            if(!Input.GetMouseButton(0))
            {
                image.color = new Color(255, 255, 255, 0);
            }
            else
            {
                image.color = new Color(255, 255, 255, 255);
            }
        }
        else
        {
            if (Input.touchCount==0)
            {
                image.color = new Color(255, 255, 255, 0);
            }
            else
            {
                image.color = new Color(255, 255, 255, 255);
            }
        }



        //animation
        transform.Rotate(0, 0, touch_knob.inputX/4);
        if (Mathf.Abs(touch_knob.inputX/50)>= 1)
        {
            if (Mathf.Abs(touch_knob.inputX / 800) >= 2)
            {
                transform.localScale = new Vector3(2, 2, 0);

            }
            else
            {
                transform.localScale = new Vector3(1 + Mathf.Abs(touch_knob.inputX / 800), 1 + Mathf.Abs(touch_knob.inputX / 800), 0);
            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
	}
}
