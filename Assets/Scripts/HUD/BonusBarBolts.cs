using UnityEngine;
using System.Collections;

public class BonusBarBolts : MonoBehaviour
{
    public GCscrew gCscrew;
    public float min;
    Transform transform;
    
	void Start ()
    {
        transform = GetComponent<Transform>();
	}
	
	void Update ()
    {
        if (gCscrew.bonusFill > (min + 10))
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if ((gCscrew.bonusFill - min) >= 0)
        {
            transform.localScale = new Vector3((gCscrew.bonusFill - min) / 10, (gCscrew.bonusFill - min) / 10, 0);
        }
        else
        {
            transform.localScale = new Vector3(0,0,0);

        }
    }
}
