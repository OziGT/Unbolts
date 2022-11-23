using UnityEngine;
using System.Collections;


public class PauseMenuMovement : MonoBehaviour
{
    public bool onMove =false;
    bool previousPause;
    public GCscrew gCscrew;
    Transform transform;

	// Use this for initialization
	void Start ()
    {
        previousPause = gCscrew.paused;
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(previousPause!=gCscrew.paused)
        {
            onMove = true;
            previousPause = gCscrew.paused;
        }

        if(onMove&&gCscrew.paused)
        {
            transform.localPosition = new Vector3(Mathf.MoveTowards(transform.localPosition.x, 0, 165 * Time.deltaTime), Mathf.MoveTowards(transform.localPosition.y, 0, 2190 * Time.deltaTime), 0);
            if(transform.localPosition.x==0)
            {
                onMove = false;
            }
        }

        if (onMove && !gCscrew.paused)
        {
            transform.localPosition = new Vector3(Mathf.MoveTowards(transform.localPosition.x, 55, 165 * Time.deltaTime), Mathf.MoveTowards(transform.localPosition.y, 730, 2190 * Time.deltaTime), 0);
            if (transform.localPosition.y == 730)
            {
                onMove = false;
            }
        }
    }
}
