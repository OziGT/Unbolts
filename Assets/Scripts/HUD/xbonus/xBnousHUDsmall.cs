using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xBnousHUDsmall : MonoBehaviour
{
    Image image;
    public int type;
    public GCscrew gCscrew;
	void Start ()
    {
        image = GetComponent<Image>();
        image.enabled = false;
	}
	
	void Update ()
    {
	    if(type==gCscrew.xBonus)
        {
            image.enabled = true;
            
            image.transform.localPosition = new Vector3(
                Mathf.MoveTowards(image.transform.localPosition.x, -49, 100 * Time.deltaTime),
                Mathf.MoveTowards(image.transform.localPosition.y, 48, 100 * Time.deltaTime)
                , 0);
                
            image.transform.localScale = new Vector3(
                Mathf.MoveTowards(image.transform.localScale.x, 0.4f, 2*Time.deltaTime),
                Mathf.MoveTowards(image.transform.localScale.y, 0.4f, 2*Time.deltaTime)
                , 0);
                
        }
        else
        {
            image.enabled = false;
            image.transform.localPosition = new Vector3(0, 0, 0);
            image.transform.localScale = new Vector3(1, 1, 1);

        }
        /*
        if (gCscrew.xBonus == 0)
        {
            image.transform.localPosition = new Vector3(0, 0, 0);
            image.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            image.transform.localPosition = new Vector3(
                Mathf.MoveTowards(image.transform.position.x, -48.8f, 1),
                Mathf.MoveTowards(image.transform.position.y, 47.95f, 1)
                , 0);
            image.transform.localScale = new Vector3(
                Mathf.MoveTowards(image.transform.localScale.x, 0.4f, 1),
                Mathf.MoveTowards(image.transform.localScale.y, 0.4f, 1)
                , 0);
        }
        */
    }
}
