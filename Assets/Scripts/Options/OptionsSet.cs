using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class OptionsSet : MonoBehaviour
{
    public bool setSounds, setMusic, setEffects;
    public GameObject gameobject;
    static string filePath;
    static OptionsSet optionsInstance;
    string[] options;

    void Start ()
    {
        filePath = Application.persistentDataPath + "/Options.txt";
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "True True True");
        }
        options = File.ReadAllText(filePath).Split(' ');
        setMusic = options[0].Equals("True");
        setEffects = options[1].Equals("True");
        setSounds = options[2].Equals("True");
    }

    public void saveScores()
    {
        File.WriteAllText(filePath, setMusic.ToString()  + " " + setEffects.ToString() + " " + setSounds.ToString());
        gameobject.SetActive(false);
    }

    public void saveCancel()
    {
        options = File.ReadAllText(filePath).Split(' ', '\n');
        setMusic = options[0].Equals("True");
        setEffects = options[1].Equals("True");
        setSounds = options[2].Equals("True");
        gameobject.SetActive(false);
    }

    void Update ()
    {

    }

    public void ChangeSounds()
    {
        setSounds = !setSounds;
    }
    public void ChangeMusic()
    {
        setMusic = !setMusic;
    }
    public void ChangeEffects()
    {
        setEffects = !setEffects;
    }
}
