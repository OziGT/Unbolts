using UnityEngine;
using System.Collections;
using System.IO;


public class SaveScoreWhenFail : MonoBehaviour
{
    GCscrew gCscrew;
    string filePath;

    // Use this for initialization
    void Start()
    {
        gCscrew = GetComponent<GCscrew>();
        filePath = Application.persistentDataPath + "/screwhs.txt";
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveScores(int score)
    {
        int[] scores = new int[50];
        int place = 0, size = 0;
        bool once = true;
        string[] lines = File.ReadAllLines(filePath);
        int j = 0;
        if (lines.Length > 0)
        {
            foreach (string i in lines)
            {

                int.TryParse(i, out scores[j]);
                if (score > scores[j] && once)
                {
                    place = j;
                    once = false;
                }
                if (j == 50)
                {
                    break;
                }
                if (score == scores[j])
                {
                    break;
                }
                j++;
            }
            if (!once)
            {
                string[] newlines = new string[lines.Length + 1];
                for (int i = 0; i < lines.Length; i++)
                {
                    newlines[i] = lines[i];
                }
                for (int i = newlines.Length; i > place; i--)
                {
                    if (i == 1)
                    {
                        break;
                    }
                    newlines[i - 1] = newlines[i - 2];
                }
                newlines[place] = score.ToString();

                File.WriteAllLines(filePath, newlines);
            }
        }
        else
        {
            File.WriteAllText(filePath, score.ToString() + "\n");
        }

    }
}
