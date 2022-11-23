using UnityEngine;
using System.Collections;

public class Roller : MonoBehaviour
{

    public GCscrew gCscrew;
    Transform transform;
    float roll=200;
	// Use this for initialization
	void Start ()
    {
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gCscrew.fail||gCscrew.pass)
        {
            roll = 0;
        }
	    if(roll<180)
        {
            roll += (gCscrew.speed*2)*Time.deltaTime;
            transform.localEulerAngles += new Vector3(0, 0, -gCscrew.speed *1.5f* Time.deltaTime);
        }
	}
}
