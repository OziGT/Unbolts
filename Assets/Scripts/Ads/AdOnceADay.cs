using UnityEngine;
using System.Collections;
using System.IO;

public class AdOnceADay : MonoBehaviour {

    public bool play;
    string filePath;
    string dateNow, dateFile;

    void Start ()
    {
        filePath = Application.persistentDataPath + "/D.scr";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();            
            //File.WriteAllText(filePath, Md5Sum(System.DateTime.Now.DayOfYear.ToString()));
            play = true;
        }
        else
        {
            Debug.Log(System.DateTime.Now.DayOfYear.ToString());
            dateNow = Md5Sum(System.DateTime.Now.DayOfYear.ToString());
            dateFile = File.ReadAllText(filePath);
            play = !dateNow.Equals(dateFile);
            Debug.Log("NOW " + dateNow);
            Debug.Log("FILE " + dateFile);
        }
    }
	
    public void UpdateDate()
    {
        File.WriteAllText(filePath, Md5Sum(System.DateTime.Now.DayOfYear.ToString()));
        play = false;
    }

    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }
}
