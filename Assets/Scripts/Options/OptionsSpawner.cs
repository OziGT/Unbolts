using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsSpawner : MonoBehaviour
{
    public Canvas canvas;
    GameObject Options;
	// Use this for initialization
	void Start ()
    {
        Options = Resources.Load<GameObject>("UI/Options");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void EnableOptions()
    {
        GameObject options = Instantiate(Options) as GameObject;
        options.transform.SetParent(canvas.transform, false);
    }
}


