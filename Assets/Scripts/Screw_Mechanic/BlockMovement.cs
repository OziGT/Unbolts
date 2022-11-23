using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour
{
    public GCscrew gCscrew;
    Transform transform;
    float  endPos;
    Animator screwAnimControl;
    int animationInt, previousScrews = 0, previousBonus;
    float speed=100;

    void Start ()
    {
        transform = GetComponent<Transform>();
        endPos = transform.position.x;
        animationInt = Animator.StringToHash("ScrewAnimControl");
        screwAnimControl = GetComponent<Animator>();
        screwAnimControl.enabled = false;
        gCscrew=FindObjectOfType<Ref>().gCscrew;
        previousScrews = gCscrew.bonus;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if((gCscrew.pass)||(gCscrew.fail))
        {
            endPos -= 86;
        }
        if(transform.position.x!=endPos)
        {
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, endPos, gCscrew.speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if(transform.position.x<-260)
        {
            Destroy(gameObject);
        }

	}
    public void animOut()
    {
        screwAnimControl.enabled = true;
        screwAnimControl.SetInteger(animationInt, 1);
    }
    public void animIn()
    {
        screwAnimControl.enabled = true;
        screwAnimControl.SetInteger(animationInt, 2);
    }

    void speedChange()
    {
        if(gCscrew.screws!=previousScrews && speed<400)
        {
            speed++;
            previousScrews = gCscrew.screws;
        }
        if(previousBonus<gCscrew.bonus)
        {
            speed += 40 * gCscrew.bonus;
          //  previousBonus = gCscrew.bonus;
        }
        else if(previousBonus>gCscrew.bonus)
        {
            speed -= 40 * gCscrew.bonus;
           // previousBonus = gCscrew.bonus;
        }
        previousBonus = gCscrew.bonus;
    }
}
