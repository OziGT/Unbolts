using UnityEngine;
using System.Collections;

public class TutorialCylinderArrows : MonoBehaviour
{

    public bool right, left;
    public GCscrew gCscrew;
    int count = 0;
    MeshRenderer mr;
    void Start ()
    {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gCscrew.pass || gCscrew.fail)
        {
            count++;
        }
        if (count == 0)
        {
            if (left)
            {
                mr.enabled = false;
                
            }
            if (right)
            {
                mr.enabled = true;
               
            }
            
        }
        if (count == 1)
        {
            if (left)
            {
                mr.enabled = true;
            }
            if (right)
            {
                mr.enabled = false;
            }

        }
        if (count == 2)
        {
            gameObject.active = false;

        }
    }
}
