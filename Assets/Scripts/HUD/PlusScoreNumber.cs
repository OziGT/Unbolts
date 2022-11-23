using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlusScoreNumber : MonoBehaviour
{

    public GCscrew gCscrew;
    //int currentScore;
    RectTransform transform;
    Text text;
    Color invisible = new Color(0, 0, 0, 0);
    bool playing;
   // public PlusScoreNumber plusScoreNumber;
    //float verticalPosChange;
    Vector3 defPosition;
    public int number;
    public PlusScoreManager manager;
	void Start ()
    {
        manager.currentScore = gCscrew.bonus;
        transform = GetComponent<RectTransform>();
        text = GetComponent<Text>();
        defPosition = transform.localPosition;

        text.color = invisible;
	}
	
	void Update ()
    {
        if (!playing)
        {
            if (number == manager.number)
            {
                if (gCscrew.bonus > manager.currentScore)
                {
                    text.text = "+" + (gCscrew.bonus - manager.currentScore);
                    text.color = new Color(0, 1, 0, 1);
                    manager.currentScore = gCscrew.bonus;
                    manager.number++;
                    if (manager.number >= 4)
                    {
                        manager.number = 0;
                    }
                    playing = true;
                }
                else if (gCscrew.bonus < manager.currentScore)
                {
                    text.text = "" + (gCscrew.bonus - manager.currentScore);
                    text.color = new Color(1, 0, 0, 1);
                    manager.currentScore = gCscrew.bonus;
                    manager.number++;
                    if (manager.number >= 4)
                    {
                        manager.number = 0;
                    }
                    playing = true;
                }
                
            }
        }
        else
        {
            Play();
        }
	}

    void Play()
    {
        transform.localPosition += new Vector3(100, -20) * Time.deltaTime;
        transform.localScale += new Vector3(0.5f, 0.5f) * Time.deltaTime;
        text.color -= new Color(0, 0, 0, 0.6f) * Time.deltaTime;
        if(transform.localPosition.x>80)
        {
            transform.localScale = new Vector3(1, 1);
            text.color = invisible;
            transform.localPosition = defPosition;
            playing = false;
        }
    }
}
