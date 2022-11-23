using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ResetScores : MonoBehaviour
{

    string filePath;
    // Use this for initialization
    
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void ResetScoresMet()
    {
        filePath = Application.persistentDataPath + "/B.scr";
        File.WriteAllText(filePath, "");
    }

}


