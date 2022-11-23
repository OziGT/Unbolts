using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour
{
    public bool buttonsVisible = true;
    float size = 2.5f;
    Transform transform;
	// Use this for initialization
	void Start ()
    {
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale = new Vector3(transform.localScale.x, Mathf.MoveTowards(transform.localScale.y, size, 5 * Time.deltaTime));
	}

    public void Local()
    {
        size = 2.8f;
        buttonsVisible = false;
    }
    public void Global()
    {
        size = 2.5f;
        buttonsVisible = true;
    }
}
