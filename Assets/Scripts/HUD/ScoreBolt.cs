using UnityEngine;
using System.Collections;

public class ScoreBolt : MonoBehaviour
{
    public GCscrew gCscrew;
    int lastScore = 0;
    Transform transform;
    float degree;

	void Start ()
    {
        transform = GetComponent<Transform>();
        degree = transform.localRotation.y;
	}
	
	void Update ()
    {
	    if(gCscrew.score!=lastScore)
        {
            degree += 180;
            lastScore = gCscrew.score;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.MoveTowardsAngle(transform.localEulerAngles.y, degree,750* Time.deltaTime), transform.localEulerAngles.z);
	}

    
}
