using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadDefaultName : MonoBehaviour
{
    public SaveFile save;
    public Text text;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        text.text = save.text.text;
	}
}
