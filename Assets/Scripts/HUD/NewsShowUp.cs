using UnityEngine;
using System.Collections;

public class NewsShowUp : MonoBehaviour
{
    RectTransform rect;
    float y;
	// Use this for initialization
	void Start ()
    {
        rect = GetComponent<RectTransform>();
        y = -135;
        rect.localPosition = new Vector3(0, y, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        rect.localPosition = new Vector3(0, y, 0);
        if(y<0)
        {
            y += 150 * Time.deltaTime;
        }
	}
}
