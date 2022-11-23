using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScoreText : MonoBehaviour
{
    public GCscrew gCscrew;
    float score;
    Text text;
    bool screenShowup;
	void Start ()
    {
        score = 0;
        screenShowup = false;
        text = GetComponent<Text>();
        text.enabled = false;
	}

	void Update ()
    {
	    if(gCscrew.bonus==-1)
        {
            text.enabled = true;
            if(score<gCscrew.score)
            {
                score += 1+Mathf.Round((float)gCscrew.score / 100);
                if(score>gCscrew.score)
                {
                    score = gCscrew.score;
                }
            }
        }
        text.text = score.ToString();
	}
}
