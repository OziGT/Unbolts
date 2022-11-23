using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GCscrew : MonoBehaviour
{
    public bool pass,fail,lost=false;
    public bool touchScreenTrue, devStaticBonus;
    [Range(-2, 5)]
    public int bonus;
    public int screwingSpeedMultiply, score, screws,xBonus = 0,speed;
    [Range(0, 90)]
    public float bonusFill;
    public bool paused = false;
    public bool canSwipe = true;
    BlockSpeed blockSpeed;
    //SaveScoreWhenFail saveScore;
    //public HSFile saveScore;
    void Start ()
    {
        score = 0;
        pass = false;
        fail = false;
        blockSpeed = GetComponent<BlockSpeed>();
        //saveScore = GetComponent<SaveScoreWhenFail>();
	}
	
	void Update ()
    {
        if (touchScreenTrue)
        {
            if (!canSwipe)
            {
                if (Input.touchCount == 0)
                {
                    canSwipe = true;
                }
            }
        }
	    if(pass)
        {
            canSwipe = false;
            pass = false;
        }
        if(fail)
        {
            canSwipe = false;
            fail = false;
            //saveScore.SaveScores(score);
        }
        if(lost)
        {
            
            //lost = false;
        }
        speed = blockSpeed.speed;

	}
    
    public void Unlost()
    {
        lost = false;
    }
    public void Pause()
    {
        paused = true;
    }
    public void UnPause()
    {
        paused = false;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("DevScrew");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
