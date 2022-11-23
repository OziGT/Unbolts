using UnityEngine;
using System.Collections;
using System.IO;

public class CreateID : MonoBehaviour
{
    string filePath;
    string id = null;
    // Use this for initialization
    //GameObject gb;
    void Start ()
    {
        
        //filePath = Application.persistentDataPath + "/A.scr";
        //gb = gameObject;
        
    }

	void Awake()
    {
        filePath = Application.persistentDataPath + "/A.scr";
        if (!File.Exists(filePath))
        {
            for (int i = 0; i < 16; i++)
            {
                id += (char)('A' + Random.Range(0, 26));
            }
            File.WriteAllText(filePath, id);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
	// Update is called once per frame
	void Update ()
    {
	
	}
}
