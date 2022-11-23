using UnityEngine;
using System.Collections;

public class HSContentSizeFitter : MonoBehaviour
{
    RectTransform rect;
    RectTransform childRect;
    public float a;
	
	void Start ()
    {
        rect = GetComponent<RectTransform>();
        childRect = GetComponentInChildren<RectTransform>();
	}
	
	
	void Update ()
    {
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, a/*childRect.sizeDelta.y*/);
	}
}
