using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xBonusOverlayAnimation : MonoBehaviour {
    
    public GCscrew gCscrew;
    Animation animation;
    Image image;
    int currentAnimation = 0;
    int currentXBonus;


    void Start()
    {
        
        animation = GetComponent<Animation>();
        image = GetComponent<Image>();
        currentXBonus = gCscrew.xBonus;
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
        if (i != currentAnimation)
        {
            animation.Play(this[i].name);
        }
        else if (!animation.isPlaying)
        {
            animation.Play(this[i].name);
        }
    }

    void Update()
    {
        if(currentXBonus!=gCscrew.xBonus)
        {
            if(currentXBonus==0)
            {
                PlayAnimation(1);
                switch (gCscrew.xBonus)
                {
                    case 1:
                        image.color = Color.yellow;
                        break;
                    case 2:
                        image.color = Color.blue;
                        break;
                    case 3:
                        image.color = Color.red;
                        break;
                    case 4:
                        image.color = Color.cyan;
                        break;
                    case 5:
                        image.color = Color.green;
                        break;

                }
            }
            else
            {
                PlayAnimation(0);
            }
            currentXBonus = gCscrew.xBonus;

        }
    }
}
