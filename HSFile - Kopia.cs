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
	// Use this for initialization
	void Start ()
    {
        filePath = Application.persistentDataPath + "/screwhs.txt";
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
        //gCscrew = FindObjectOfType<Ref>().gCscrew;
        EncryptionTest();

    }

    void EncryptionTest()
    {
        string test = "Kozie mleko \n 542";
        string hash,hash2;
        SimplerAES aes=null;
        hash=aes.Encrypt(test);
        Debug.Log(hash);
        hash2 = aes.Decrypt(hash);
        Debug.Log(hash2);

    }

    public void LoadLoadScores()
    {
        //StartCoroutine(LoadScores());
        scores = File.ReadAllText(filePath);
        text.text = scores;
        score.text = "";


    }
    IEnumerator LoadScores()
    {
       // StreamReader file = new StreamReader(filePath);
       // scores = file.ReadToEnd();
        scores = File.ReadAllText(filePath);
       // file.Close();
        text.text = scores;
        score.text = "";
        yield return true;
    }

    string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }



    public void SaveScores(int score)
    {

        int[] scores=new int[50];
        int place = 0, size = 0;
        bool once = true;
        string[] lines = File.ReadAllLines(filePath);
        int j = 0;
        bool skipHash = true;
        if (lines.Length > 0)
        {
            foreach (string i in lines)
            {
                if(skipHash)
                {
                    skipHash = false;
                    continue;
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
                string[] newlines = new string[lines.Length+1];
                for(int i=0;i<lines.Length;i++)
                {
                    newlines[i] = lines[i];
                }
                for (int i = newlines.Length; i > place; i--)
                {
                    if(i==1)
                    {
                        break;
                    }
                    newlines[i-1] = newlines[i-2];
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
    


    void Update ()
    {
        if (once)
        {
            SaveScores(gCscrew.score);
            once = false;
        }

        
	}

    public void SubmitHS()
    {
        int Punkty;
        HSController hscontroller = GetComponent<HSController>();
        StreamReader file = new StreamReader(Application.persistentDataPath + "/screw.txt");
        string Gracz = file.ReadLine();
        StreamReader fileW = new StreamReader(Application.persistentDataPath + "/screwhs.txt");
       // string p = file.ReadLine();
        int.TryParse(fileW.ReadLine(), out Punkty);
        hscontroller.post(Gracz, Punkty);
        file.Close();
        fileW.Close();
    }
}


public class SimplerAES
{
    private static byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
    private static byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };
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