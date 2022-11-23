using UnityEngine;
using System.Collections;

public class BonusPoints : MonoBehaviour
{
    GCscrew gCscrew;
    int previousScore,previousScrews=0,previousBonus,previousXBonus=0;
    public float[] bonusSetup;
    float depleteRate = 1;
    public float previewDepleteRateCheck=1;
    public float deplateRateSetup;
    bool xbonusStarted = false;
    int lastXbonus;
    public HSFile saveScore;
    int minusXbonusMultipler=1;
    public float deplateAccelerator;
    void Start()
    {
        gCscrew = GetComponent<GCscrew>();
        gCscrew.bonusFill = 40;
        previousScore = gCscrew.score;
        
    }

    void Update()
    {

        XBonus();
      

        if (!gCscrew.paused && !gCscrew.devStaticBonus)    //pauza, dev, xbonus aktywny
        {
            if (gCscrew.xBonus != 1 && gCscrew.screws>1)
            {
                Deplete();
            }

            if ((gCscrew.bonusFill > 90) && (gCscrew.bonus != 5))
            {
                gCscrew.bonus++;
                gCscrew.bonusFill = 20;
            }
            else if ((gCscrew.bonusFill > 90) && (gCscrew.bonus == 5))
            {
                gCscrew.bonusFill = 90;
            }
            else if (gCscrew.bonusFill < 0)
            {
                gCscrew.bonus--;
                if(gCscrew.bonus==0)
                {
                    gCscrew.fail = true;
                }
                gCscrew.bonusFill = 89;
            }
            if (previousScore != gCscrew.score)
            {
                gCscrew.bonusFill += 10;
            }
            /*
            if(gCscrew.pass&&gCscrew.bonus==0)
            {
                gCscrew.bonusFill += 10;
            }
            */
            if(gCscrew.fail)
            {

                gCscrew.bonus-=1;
                gCscrew.bonusFill = 10;
                gCscrew.fail = false;
                if(gCscrew.bonus<1)
                {
                    //gCscrew.bonus -= 1;
                    gCscrew.Pause();
                    gCscrew.lost = true;
                    saveScore.SaveScores(gCscrew.score+gCscrew.screws);
                }
            }
            previousScore = gCscrew.score;
        }
        
    }
    

    void Deplete()
    {
        deplateAccelerator += (0.025f * (gCscrew.bonus / minusXbonusMultipler)) * Time.deltaTime;
        if (gCscrew.bonus >= 0)
        {
            if (gCscrew.xBonus == 3)
                minusXbonusMultipler = 3;
            else if (gCscrew.xBonus == 4)
                minusXbonusMultipler = 2;
            else
                minusXbonusMultipler = 1;

            if (gCscrew.screws < 200)
            {
                previewDepleteRateCheck = (bonusSetup[gCscrew.bonus] + (gCscrew.screws * deplateRateSetup*gCscrew.bonus/minusXbonusMultipler)) * Time.deltaTime+deplateAccelerator;
            }
            else
            {
                previewDepleteRateCheck = (bonusSetup[gCscrew.bonus] + (200 * deplateRateSetup * gCscrew.bonus / minusXbonusMultipler)) * Time.deltaTime+deplateAccelerator;
            }
            gCscrew.bonusFill -= previewDepleteRateCheck ;
        }
        previousScrews = gCscrew.screws;
        if(gCscrew.fail||gCscrew.pass)
        {
            deplateAccelerator = 0;
        }
    }
    
    void XBonus()
    {

        
        if (gCscrew.xBonus == 0 && !xbonusStarted)
        {
            previousBonus = gCscrew.bonus;
        }
        else if(gCscrew.xBonus==0 && xbonusStarted)
        {
            if(previousXBonus==3)
            {
                gCscrew.bonus /= 3;
            }
            else if(previousXBonus==4)
            {
                gCscrew.bonus /= 2;
            }
            xbonusStarted = false;
        }
        if(gCscrew.xBonus==3)
        {
            gCscrew.bonus = previousBonus * 3;
            xbonusStarted = true;
        }
        if (gCscrew.xBonus == 4)
        {
            gCscrew.bonus = previousBonus * 2;
            xbonusStarted = true;
        }



        previousXBonus = gCscrew.xBonus;
        
    }
}
