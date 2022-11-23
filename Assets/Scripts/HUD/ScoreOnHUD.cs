using UnityEngine;
using System.Collections;

public class ScoreOnHUD : MonoBehaviour
{
    public GCscrew gCscrew;
    int previousScore;
    public bool P;
    TextMesh text;
    bool front = true;
	void Start ()
    {
        text = GetComponent<TextMesh>();
        previousScore = gCscrew.score;

    }

    // Update is called once per frame
    void Update ()
    {
        
        if (previousScore != gCscrew.score) //SCORE
        {
            if (front)
            {
                if (!P)
                {
                    text.text = gCscrew.score.ToString();
                }
                front = false;
            }
            else
            {
                if (P)
                {
                    text.text = gCscrew.score.ToString();

                }
                front = true;
            }
            previousScore = gCscrew.score;
        }


        if (gCscrew.score < 10)
        {
            text.fontSize = 365;
        }
        else if (gCscrew.score < 100)
        {
            text.fontSize = 270;
        }
        else if (gCscrew.score < 1000)
        {
            text.fontSize = 200;
        }
        else if(gCscrew.score<10000)
        {
            text.fontSize = 155;
        }
        else if (gCscrew.score < 100000)
        {
            text.fontSize = 120;
        }
    }
}
