using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;

public class SaveFile : MonoBehaviour
{
    string filePath;
    //public string name;
    public Text text;
    public Text rightText;
    //Text text;
    public GameObject createID,CreateIDName;
    
	void Start ()
    {
        //text = GetComponent<Text>();//
        StartCoroutine(LoadFile());
        
        
    }

    IEnumerator LoadFile()
    {
        filePath = Application.persistentDataPath + "/C.scr";
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Default");
            text.text = "Default";
        }
        else
        {

            StreamReader file = new StreamReader(filePath);
            text.text = file.ReadLine();
            file.Close();

        }
        yield return null;
    }

    public void  ChangeName()
    {
        
        //name = text.text;
        File.WriteAllText(filePath, rightText.text);
        createID.SetActive(false);
        CreateIDName.SetActive(false);
        /*
        name = text.text;
        StreamWriter file = new StreamWriter(filePath);
        file.WriteLine(name);
        */
    }
}
