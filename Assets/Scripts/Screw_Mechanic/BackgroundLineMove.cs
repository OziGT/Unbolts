using UnityEngine;
using System.Collections;

public class BackgroundLineMove : MonoBehaviour
{

    public GCscrew gCscrew;
    Transform transform;
    float roll = 200;
    // Use this for initialization
    void Start ()
    {
        transform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(gCscrew.fail || gCscrew.pass)
        {
            roll = 0;
        }
        if(roll < 180)
        {
            roll += (gCscrew.speed * 2) * Time.deltaTime;
            transform.localPosition += new Vector3(gCscrew.speed *0.1f* Time.deltaTime, 0, 0);
        }
        if(transform.position.x>193)
        {
            transform.position = new Vector3(-455, transform.position.y, transform.position.z);
        }
    }
}
