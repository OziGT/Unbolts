using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameFieldToGC : MonoBehaviour
{
    public SaveFile save;
    Text text;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        save.name = text.text;
	}
}
