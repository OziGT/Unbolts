using UnityEngine;
using System.Collections;

public class GameOverHudTurnOff : MonoBehaviour
{
    public GameObject[] elements;
    GCscrew gCscrew;
    bool lost = true;
	void Start ()
    {
        gCscrew = GetComponent<GCscrew>();
	}
	
	void Update ()
    {
	    if(lost && gCscrew.lost)
        {
            foreach(GameObject i in elements)
            {
                i.SetActive(false);
            }
            lost = false;
        }
	}
}
