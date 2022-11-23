using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPressedAnimation : MonoBehaviour
{
    Transform transform;
    Image image;
    bool animate = false;

    void Animate()
    {
        transform.localScale = new Vector3(Mathf.MoveTowards(transform.localScale.x, 1,2* Time.deltaTime), Mathf.MoveTowards(transform.localScale.y, 1, 2*Time.deltaTime), transform.localScale.z);
        if(transform.localScale.x==1)
        {
            animate = false;
        }
    }
	void Start ()
    {
        transform = GetComponent<Transform>();
        image = GetComponent<Image>();
	}
	
    public void AnimateTrue()
    {
        animate = true;
        transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z);
    }
	
	void Update ()
    {
	    if(animate)
        {
            Animate();
        }
	}
}
