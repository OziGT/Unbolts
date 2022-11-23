using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    Image image;
    Text text;
    public bool isImage;
    public GCscrew gCscrew;
    float score,screws,total;
    public int type;

    void Start()
    {
        if (isImage)
        {
            image = GetComponent<Image>();
        }
        else
        {
            text = GetComponent<Text>();
            score =screws=total= 0;
            text.enabled = false;
        }

    }

    void Update()
    {
        if (isImage)
        {
            if (gCscrew.lost)
            {
                image.enabled = true;
            }
        }
        else
        {
            switch (type)
            {
                case 1:
                    if (gCscrew.lost)
                    {

                        text.enabled = true;
                        if (score < gCscrew.score)
                        {
                            score += 1 + Mathf.Round((float)gCscrew.score / 100);
                            if (score > gCscrew.score)
                            {
                                score = gCscrew.score;
                            }
                        }
                    }

                    text.text = score.ToString();
                    break;
                case 2:
                    if (gCscrew.lost)
                    {

                        text.enabled = true;
                        if (screws < gCscrew.screws)
                        {
                            screws += 1 + Mathf.Round((float)gCscrew.screws / 100);
                            if (screws > gCscrew.screws)
                            {
                                screws = gCscrew.screws;
                            }
                        }
                    }
                    text.text = screws.ToString();
                    break;
                case 0:
                    if (gCscrew.lost)
                    {

                        text.enabled = true;
                        if (total < gCscrew.screws+gCscrew.score)
                        {
                            total += 1 + Mathf.Round((float)(gCscrew.screws + gCscrew.score) / 100);
                            if (total > gCscrew.screws + gCscrew.score)
                            {
                                total = gCscrew.screws + gCscrew.score;
                            }
                        }
                    }

                    text.text = total.ToString();
                    break;
                case 3:
                    if (gCscrew.lost)
                    {

                        text.enabled = true;
                        
                    }

                    break;
            }
        }
    }



    public void Hide()
    {
        if (isImage)
        {
            image.enabled = false;
        }
        else
        {
            text.enabled = false;
        }
        gCscrew.bonus = 0;
    }
}
