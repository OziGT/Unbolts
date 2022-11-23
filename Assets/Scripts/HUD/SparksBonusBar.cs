using UnityEngine;
using System.Collections;

public class SparksBonusBar : MonoBehaviour
{
    public GCscrew gCscrew;
    public ParticleSystem sparks;
    int bonus;
	// Use this for initialization
	void Start ()
    {
        bonus = gCscrew.bonus;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(gCscrew.bonus>bonus)
        {
            sparks.Play();
            bonus = gCscrew.bonus;
        }
        else if(gCscrew.bonus<bonus)
        {
            bonus = gCscrew.bonus;
        }
    }
}
