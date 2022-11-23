using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;
using System.Security.Cryptography;
using System.Text;

public class HSFile : MonoBehaviour
{
    string filePath;
    string scores;
    public GCscrew gCscrew;
    public bool once;
    public Text score;
    public Text text;


    void Start()
    {

        filePath = Application.persistentDataPath + "/B.scr";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

    }

    void EncryptionTest()
    {
        string test = "Kozie mleko \n 542";
        string hash, hash2;
        SimplerAES aes = new SimplerAES();
        hash = aes.Encrypt(test);
        hash2 = aes.Decrypt(hash);

    }

    public void LoadLoadScores()
    {
        filePath = Application.persistentDataPath + "/B.scr";
        if (File.ReadAllText(filePath) == "")
        {
            text.text = "";
            score.text = "No scores saved";
        }
        else
        {
            SimplerAES aes = new SimplerAES();
            scores = aes.Decrypt(File.ReadAllText(filePath));
            string[] lines = scores.Split('\n');

            text.text = scores;
            score.text = "";

            /*
            int j = 0;
            foreach (string i in lines)
            {
                if (i == "\n" || i=="")
                {
                    continue;
                }
                
                if (!int.TryParse(i, out j))
                {
                    
                    text.text = "Highscore file broken!";
                    j = 99999999;
                    break;
                   
                    
                }
                
            }
            if (j != 99999999)
            {
                text.text = scores;
                score.text = "";
            }
            */
        }

    }
    IEnumerator LoadScores()
    {
        scores = File.ReadAllText(filePath);
        text.text = scores;
        score.text = "";
        yield return true;
    }



    public void SaveScores(int score)
    {
        SimplerAES aes = new SimplerAES();
        string temp;
        string Joined;
        filePath = Application.persistentDataPath + "/B.scr";

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        if (File.ReadAllText(filePath) == "")
        {
            temp = score.ToString() + "\n";
            File.WriteAllText(filePath, aes.Encrypt(temp));
            return;
        }


        int[] scores = new int[50];
        int place = 0, size = 0;
        bool once = true;
        temp = File.ReadAllText(filePath);
        Joined = aes.Decrypt(temp);
        string[] lines = Joined.Split('\n');
        int j = 0;
        foreach (string i in lines)
        {

            if (i == "\n")
            {
                break;
            }
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
            if (newlines.Length > 50)
            {
                newlines[50] = "\0";
            }
            Joined = String.Join("\n", newlines);
            temp = aes.Encrypt(Joined);
            File.WriteAllText(filePath, temp);
        }



        return;
    }



    void Update()
    {
    }

    public void SubmitHS()
    {
        Debug.Log("SubmitHS");
        SimplerAES aes = new SimplerAES();
        string temp;

        int Punkty;
        HSController hscontroller = GetComponent<HSController>();
        StreamReader file = new StreamReader(Application.persistentDataPath + "/C.scr");
        string Gracz = file.ReadLine();
        temp = aes.Decrypt(File.ReadAllText(Application.persistentDataPath + "/B.scr"));
        string[] lines = temp.Split('\n');
        int.TryParse(lines[0], out Punkty);
        hscontroller.post(Gracz, Punkty);
        file.Close();
    }
}


class SimplerAES
{

    private static byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
    private static byte[] vector = File.ReadAllBytes(Application.persistentDataPath + "/A.scr"); //{ 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209 };//
    private ICryptoTransform encryptor, decryptor;
    private UTF8Encoding encoder;

    public SimplerAES()
    {
        RijndaelManaged rm = new RijndaelManaged();
        encryptor = rm.CreateEncryptor(key, vector);
        decryptor = rm.CreateDecryptor(key, vector);
        encoder = new UTF8Encoding();
    }

    public string Encrypt(string unencrypted)
    {
        return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
    }

    public string Decrypt(string encrypted)
    {
        return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
    }

    public byte[] Encrypt(byte[] buffer)
    {
        return Transform(buffer, encryptor);
    }

    public byte[] Decrypt(byte[] buffer)
    {
        return Transform(buffer, decryptor);
    }

    protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
    {
        MemoryStream stream = new MemoryStream();
        using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
        {
            cs.Write(buffer, 0, buffer.Length);
        }
        return stream.ToArray();
    }
}