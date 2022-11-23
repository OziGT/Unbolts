using UnityEngine;
using System.Collections;

public class xBonus : MonoBehaviour
{
    public GCscrew gCscrew;
    public int xbonus;
    int bonusDistance=10;
    public int screwsToNextBonus;
    int slower=0, i=0;
	void Start ()
    {
	    
	}
	
	void Update ()
    {
	    if(gCscrew.screws==bonusDistance && gCscrew.xBonus==0)
        {
            if (i == slower)
            {
                xbonus = Mathf.RoundToInt(Random.Range(1, 6));
                i = 0;
                if (slower < 5)
                {
                    slower++;
                }
            }
            else
            {
                i++;
            }
            if(Input.touchCount>0||Input.GetMouseButton(0))
            {
                bonusDistance += screwsToNextBonus;
                gCscrew.xBonus = xbonus;
            }
        }
        else
        {
            xbonus = 0;
        }
	}
}
