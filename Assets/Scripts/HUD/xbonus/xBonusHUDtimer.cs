using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xBonusHUDtimer : MonoBehaviour
{
    Text text;
    public GCscrew gCscrew;
    float timer=5,textTime;
    public bool On;
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (On)
        {
            if (!gCscrew.paused && gCscrew.xBonus > 0)
            {
                text.enabled = true;
                timer -= Time.deltaTime;
                textTime = (float)System.Math.Round(timer, 1);
                text.text = textTime.ToString();
                if (timer <= 0)
                {
                    timer = 5;
                    gCscrew.xBonus = 0;
                }
            }
            else
            {
                text.enabled = false;
            }
        }

	}
}
