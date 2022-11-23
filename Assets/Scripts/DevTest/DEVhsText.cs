using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DEVhsText : MonoBehaviour {

    public HSSpacing spacing;
    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = spacing.textHeight.ToString();
	}
    public void add()
    {
        spacing.textHeight += 0.005f;
    }
    public void sub()
    {
        spacing.textHeight -= 0.005f;
    }
}
