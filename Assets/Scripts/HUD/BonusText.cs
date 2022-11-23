using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusText : MonoBehaviour
{
    Text text;
    public GCscrew gCscrew;

	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	void Update ()
    {
        if (gCscrew.bonus >= 0)
        {
            text.text = "x" + gCscrew.bonus.ToString();
        }
        else
        {
            text.text = "x0";
        }
	}
}
