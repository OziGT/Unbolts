using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class V : MonoBehaviour
{
    public bool up;
    float startPosition;
    RectTransform rectTransform;
    Image image;
    public GCscrew gCscrew;
    int previousBonus;
    bool start;
	void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        startPosition = transform.localPosition.y;
        previousBonus = gCscrew.bonus;
        start = false;
	}
	
	void Update ()
    {
        if(gCscrew.fail)
        {
            gameObject.SetActive(false);
        }
	    if(up)
        {
            if(previousBonus<gCscrew.bonus)
            {
                rectTransform.localPosition = new Vector3(0, startPosition,0);
                image.color = new Color(1, 1, 1, 0);
                start = true;
                
            }
            if(start)
            {
                rectTransform.localPosition += new Vector3(0, 1500 * Time.deltaTime,0);
                image.color += new Color(1, 1, 1, 2.5f * Time.deltaTime);
                if(rectTransform.localPosition.y>500)
                {
                    start = false;
                }
            }
        }
        else
        {
            if (previousBonus > gCscrew.bonus)
            {
                rectTransform.localPosition = new Vector3(0, startPosition, 0);
                image.color = new Color(1, 1, 1, 0);
                start = true;
                
            }
            if (start)
            {
                rectTransform.localPosition -= new Vector3(0, 1500 * Time.deltaTime, 0);
                image.color += new Color(1, 1, 1, 2.5f * Time.deltaTime);
                if (rectTransform.localPosition.y < -500)
                {
                    start = false;
                }
            }
        }
        if(previousBonus!=gCscrew.bonus)
        {
            previousBonus = gCscrew.bonus;
        }
	}
}
