using UnityEngine;
using System.Collections;

public class ScrewMovement : MonoBehaviour
{
    Transform transform;
    public Touch_Knob touch_Knob;
    public GCscrew gcScrew;
    BlockMovement parent;
    bool passed = false,played = false;
    float previousInputX;
    public int type;
    AudioSource[] sounds;
    ParticleSystem spark;
    bool DEVTEST;
    OptionsSet options;

	void Start ()
    {
        transform = GetComponent<Transform>();
        parent = GetComponentInParent<BlockMovement>();
        gcScrew = FindObjectOfType<Ref>().gCscrew;
        touch_Knob = FindObjectOfType<Ref>().knob;
        options = FindObjectOfType<Ref>().optionsGlobal;
        sounds = GetComponents<AudioSource>();
        spark = parent.GetComponentInChildren<ParticleSystem>();
        
    }
	
	
	void Update ()
    {
        if (gcScrew.touchScreenTrue)
        {
            if (!gcScrew.paused && gcScrew.canSwipe)
            {
                switch (type)
                {
                    case 0:
                        type0();
                        break;
                    case 1:
                        type1();
                        break;
                    case 2:
                        type2();
                        break;
                    case 3:
                        type3();
                        break;
                }
            }
        }
        else
        {
            if (!gcScrew.paused)
            {
                switch (type)
                {
                    case 0:
                        type0();
                        break;
                    case 1:
                        type1();
                        break;
                    case 2:
                        type2();
                        break;
                    case 3:
                        type3();
                        break;
                }
            }
        }
    }

    
    void Obrot()
    {
        if (touch_Knob.inputX != 0)     //Obrot gdy dotyka
        {
            transform.RotateAroundLocal(new Vector3(0, 1, 0), -touch_Knob.inputX *Time.deltaTime);
            transform.localPosition += new Vector3(0, touch_Knob.inputX*Time.deltaTime, 0);
            previousInputX = touch_Knob.inputX;
        }
        else
        {
            transform.RotateAroundLocal(new Vector3(0, 1, 0), -previousInputX *Time.deltaTime);       //obrot samowolny
            transform.localPosition += new Vector3(0, previousInputX *Time.deltaTime, 0);
            previousInputX *= 0.9f;
            previousInputX = (float)System.Math.Round(previousInputX, 3);
        }
    }

    void ObrotReversedOut()
    {
        if (touch_Knob.inputX != 0)     //Obrot gdy dotyka
        {
            transform.RotateAroundLocal(new Vector3(0, 1, 0), -Mathf.Abs(touch_Knob.inputX) * Time.deltaTime);
            transform.localPosition -= new Vector3(0, -Mathf.Abs(touch_Knob.inputX) * Time.deltaTime, 0);
            previousInputX = -Mathf.Abs(touch_Knob.inputX);
        }
        else
        {
            transform.RotateAroundLocal(new Vector3(0, 1, 0), previousInputX * Time.deltaTime);       //obrot samowolny
            transform.localPosition -= new Vector3(0, previousInputX * Time.deltaTime, 0);
            previousInputX *= 0.9f;
            previousInputX = (float)System.Math.Round(previousInputX, 3);
        }
    }

    void ObrotReversedIn()
    {
        if (touch_Knob.inputX != 0)     //Obrot gdy dotyka
        {
            transform.RotateAroundLocal(new Vector3(0, 1, 0), Mathf.Abs(touch_Knob.inputX) * Time.deltaTime);
            transform.localPosition -= new Vector3(0, Mathf.Abs(touch_Knob.inputX) * Time.deltaTime, 0);
            previousInputX = Mathf.Abs(touch_Knob.inputX);
        }
        else
        {
            transform.RotateAroundLocal(new Vector3(0, 1, 0), previousInputX * Time.deltaTime);       //obrot samowolny
            transform.localPosition -= new Vector3(0, previousInputX * Time.deltaTime, 0);
            previousInputX *= 0.9f;
            previousInputX = (float)System.Math.Round(previousInputX, 3);
        }
    }


    void type0()//LONG IN
    {
        if (transform.position.x < 2)
        {
            if ((transform.localPosition.y <= -47) && (passed == false))   //udalo sie
            {
                gcScrew.score+=1*gcScrew.bonus;  //dodanie puntku
                gcScrew.screws++;
                PlaySound(0);
                passed = true;
                gcScrew.pass = true;
                spark.Play();
                
            }
            else if (((transform.localPosition.y+(touch_Knob.inputX * Time.deltaTime) <= -47)|| (transform.localPosition.y + (previousInputX * Time.deltaTime) <= -47)) && (passed == false))
            {
                gcScrew.score += 1 * gcScrew.bonus;    //dodanie punktu
                gcScrew.screws++;
                PlaySound(0);
                passed = true;
                gcScrew.pass = true;
                transform.localPosition = new Vector3(transform.localPosition.x, -47, transform.localPosition.z);
                spark.Play();

            }
            else if (passed) // udalo sie, nie rob nic
            {
                
            }
            else if (transform.localPosition.y > 0.5f)  //nie udalo
            {
                passed = true;
                gcScrew.fail = true;
                PlaySound(1);
                parent.animOut();
            }
            else                                        //krecimy
            {

                if (gcScrew.xBonus == 5)
                {
                    ObrotReversedIn();
                }
                else
                {
                    Obrot();
                }
            }
        }
        
    }

    void type1()//LONG OUT
    {
        if (transform.position.x < 2)
        {
            if ((transform.localPosition.y >= 0) && (passed == false))   //udalo sie
            {
                gcScrew.score += 1 * gcScrew.bonus; //dodanie punktu
                gcScrew.screws++;
                PlaySound(0);
                passed = true;
                gcScrew.pass = true;
                parent.animOut();
            }
            else if (passed) // udalo sie, nie rob nic
            {

            }
            
            else if (transform.localPosition.y < -47.5f)  //nie udalo
            {
                gcScrew.fail = true;
                parent.animIn();
                PlaySound(1);
                spark.Play();

            }
            
            else                                        //krecimy
            {
                if (gcScrew.xBonus == 5)
                {
                    ObrotReversedOut();
                }
                else
                {
                    Obrot();
                }
            }
        }
        
    }

    void type2()//SHORT IN
    {
        if (transform.position.x < 2)
        {
            if ((transform.localPosition.y <= -25.5f) && (passed == false))   //udalo sie
            {
                gcScrew.score += 1 * gcScrew.bonus;  //dodanie puntku
                gcScrew.screws++;
                PlaySound(0);
                passed = true;
                gcScrew.pass = true;
                spark.Play();

            }
            else if (((transform.localPosition.y + (touch_Knob.inputX * Time.deltaTime) <= -25.5f) || (transform.localPosition.y + (previousInputX * Time.deltaTime) <= -25.5f)) && (passed == false))
            {
                gcScrew.score += 1 * gcScrew.bonus;    //dodanie punktu
                gcScrew.screws++;
                PlaySound(0);
                passed = true;
                gcScrew.pass = true;
                transform.localPosition = new Vector3(transform.localPosition.x, -25.5f, transform.localPosition.z);
                spark.Play();

            }
            else if (passed) // udalo sie, nie rob nic
            {

            }
            else if (transform.localPosition.y > 0.5f)  //nie udalo
            {
                passed = true;
                gcScrew.fail = true;
                PlaySound(1);
                parent.animOut();
            }
            else                                        //krecimy
            {
                if (gcScrew.xBonus == 5)
                {
                    ObrotReversedIn();
                }
                else
                {
                    Obrot();
                }
            }
        }

    }

    void type3()//SHORT OUT
    {
        if (transform.position.x < 2)
        {
            if ((transform.localPosition.y >= 0) && (passed == false))   //udalo sie
            {
                gcScrew.score += 1 * gcScrew.bonus; //dodanie punktu
                gcScrew.screws++;
                PlaySound(0);
                passed = true;
                gcScrew.pass = true;
                parent.animOut();
            }
            else if (passed) // udalo sie, nie rob nic
            {

            }

            else if (transform.localPosition.y < -26)  //nie udalo
            {
                gcScrew.fail = true;
                parent.animIn();
                PlaySound(1);
                spark.Play();

            }

            else                                        //krecimy
            {
                if (gcScrew.xBonus == 5)
                {
                    ObrotReversedOut();
                }
                else
                {
                    Obrot();
                }
            }
        }

    }

    void PlaySound(int x)
    {
        
        if (!played && options.setSounds)
        {
            sounds[x].Play();
            played = true;
        }
        
    }

}



