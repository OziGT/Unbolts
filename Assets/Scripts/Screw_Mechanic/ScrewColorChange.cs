using UnityEngine;
using System.Collections;

public class ScrewColorChange : MonoBehaviour
{
    Renderer render;
    Transform transform;
    GCscrew gcScrew;
    bool passed;
    void Start ()
    {
        render = GetComponent<Renderer>();
        transform = GetComponent<Transform>();
        gcScrew = FindObjectOfType<Ref>().gCscrew;
        passed = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!passed)
        {
            if (transform.position.x <= 0)
            {
                if (gcScrew.pass)
                {
                    render.material.color = Color.green;
                    passed = true;
                }
                if (gcScrew.fail)
                {
                    render.material.color = Color.red;
                    passed = true;
                }
            }
        }
        
	}
}
