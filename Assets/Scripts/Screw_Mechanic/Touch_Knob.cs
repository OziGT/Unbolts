using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Touch_Knob : MonoBehaviour
{
    float x, y, lastX = 0;
    public float inputX = 0;
    bool untouched;
    Transform transform;
    public GCscrew gCscrew;
    void Start()
    {
        transform = GetComponent<Transform>();
        untouched = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gCscrew.touchScreenTrue)
        {
            //if (gCscrew.canSwipe)
            //{
                touchScreen();
           // }
        }
        else
        {
            mouse();
        }
        transform.position = new Vector2(x, y);
        inputX = Remap(inputX, 0, Screen.width, 0, 500);
        inputX *= gCscrew.screwingSpeedMultiply;
        
    }


    void touchScreen()
    {
        if (Input.touchCount > 0)
        {
            
            x = Input.GetTouch(0).position.x;
            y = Input.GetTouch(0).position.y;

            if (untouched)
            {
                inputX = 0;
            }
            else
            {
                inputX = x - lastX;
            }
            lastX = x;
            untouched = false;
        }
        else
        {
            untouched = true;
            inputX = 0;
        }

    }

    void mouse()
    {
        if (Input.GetMouseButton(0))
        {

            x = Input.mousePosition.x;
            y = Input.mousePosition.y;


            inputX = x - lastX;
            lastX = x;


        }
        else
        {
            lastX = Input.mousePosition.x;
            inputX = 0;
        }
    }

    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}