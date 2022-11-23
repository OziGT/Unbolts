using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public bool hand, right, left;
    public GCscrew gCscrew;
    Animation animation;
    Image image;
    int currentAnimation=0;
    int count = 0;
	void Start ()
    {
	    if(hand)
        {
            animation = GetComponent<Animation>();
            
        }
        //if(left||right)
       // {
            image = GetComponent<Image>();
        // }
        //image.color = new Vector4(1, 1, 1, 1);
	}
     AnimationState this[int index]
    {
        get
        {
            int i = 0;
            foreach (AnimationState state in animation)
            {
                if (i == index)
                {
                    return state;
                }
                i++;
            }
            return null;
        }
    }

    void PlayAnimation(int i)
    {
        if(i!=currentAnimation)
        {
            animation.Play(this[i].name);
        }
        else if(!animation.isPlaying)
        {
            animation.Play(this[i].name);
        }
    }
    void Update ()
    {
        if(gCscrew.pass||gCscrew.fail)
        {
            count++;
        }
	    if(count==0)
        {
            if(left)
            {
                image.enabled = false;
            }
            if(right)
            {
                image.enabled = true;
            }
            if(hand)
            {
                PlayAnimation(0);
            }
        }
        if (count == 1)
        {
            if (left)
            {
                image.enabled = true;
            }
            if (right)
            {
                image.enabled = false;
            }
            if (hand)
            {
                PlayAnimation(1);
            }
        }
        if(count==2)
        {
            gameObject.active = false;
            
        }
    }
}
