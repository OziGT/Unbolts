using UnityEngine;
using System.Collections;

public class LineOnRoller : MonoBehaviour
{
    public float t;
    Transform transform;
	void Start ()
    {
        transform = GetComponent<Transform>();
	}
	
	void Update ()
    {
        transform.position = new Vector3(
        transform.position.x,
        -3*Mathf.Cos(transform.position.x/16)-68,
        transform.position.z);
	}
}
