using UnityEngine;
using System.Collections;

public class BlockSpeed : MonoBehaviour
{
    public int speed=100;
    GCscrew gCscrew;
    int previousScrews, previousBonus;
	void Start ()
    {
        gCscrew = GetComponent<GCscrew>();
	}
	
	void Update ()
    {
        
            if (gCscrew.screws != previousScrews && speed < 400)
            {
                speed++;
                previousScrews = gCscrew.screws;
            }
            if (previousBonus < gCscrew.bonus)
            {
                speed += 40 * gCscrew.bonus;
                //  previousBonus = gCscrew.bonus;
            }
            else if (previousBonus > gCscrew.bonus)
            {
                speed -= 40 * gCscrew.bonus;
                // previousBonus = gCscrew.bonus;
            }
            previousBonus = gCscrew.bonus;
        

    }
}
