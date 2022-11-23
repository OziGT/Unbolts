using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class HSController : MonoBehaviour
{
    private string secretKey = "HUewri43"; 
    public string addScoreURL = "http://ozi.webd.pl/screw/addscore.php?"; 
    public string highscoreURL = "http://ozi.webd.pl/screw/display.php";
    public string hsName = "http://ozi.webd.pl/screw/displayName.php";
    public string hsNameMy = "http://ozi.webd.pl/screw/displayNameMy.php?";
    public string hsScoreMy = "http://ozi.webd.pl/screw/displayScoreMy.php?";
    public string hsNameName = "http://ozi.webd.pl/screw/displayNameName.php?";
    public string hsScoreName = "http://ozi.webd.pl/screw/displayScoreName.php?";
    public string hsScore = "http://ozi.webd.pl/screw/displayScore.php";
    public Text Name;
    public Text Score;
    public Text inputNameText;
    //string stringGet;
    void Start()
    {
        StartCoroutine(GetScores());
    }

    // remember to use StartCoroutine when calling this function!
    public void post(string Gracz,int Punkty)
    {
        StartCoroutine(PostScores(Gracz,Punkty));
        
    }

    public void show()
    {
        StartCoroutine(GetScores());
    }
    public void showMy()
    {
        StartCoroutine(GetMyScores());
    }

    public void showName()
    {
        StartCoroutine(GetNameScores(inputNameText.text));
    }

    string GetMac()
    {
        string filePath;
        string id=null;
        filePath = Application.persistentDataPath + "/A.scr";

        if (!File.Exists(filePath))
        {
            
            for(int i=0;i<16;i++)
            {
                id += (char)('A' + Random.Range(0, 48));
            }
            File.WriteAllText(filePath, id);
            return id;
        }
        else
        {

            StreamReader file = new StreamReader(filePath);
            id = file.ReadLine();
            file.Close();
            return id;
        }
    }

    IEnumerator PostScores(string Gracz, int Punkty)
    {

        string MAC = GetMac();//SystemInfo.deviceUniqueIdentifier;



        //This connects to a server side php script that will add the Gracz and score to a MySQL DB.
        // Supply it with a string representing the players Gracz and the players score.
        string hash = Md5Sum(Gracz + Punkty + secretKey);

        string post_url = addScoreURL + "Gracz=" + WWW.EscapeURL(Gracz) + "&Punkty=" + Punkty + "&MAC=" + WWW.EscapeURL(MAC) + "&hash=" + hash;
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done
        //Debug.Log(hs_post.text);
        //Debug.Log(post_url);
        Debug.Log(post_url);
        //Debug.Log(Md5Sum(Gracz));
        if (hs_post.error != null)
        {
            Debug.Log("There was an error posting the high scores: " + hs_post.error);
        }
    }

    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        //gameObject.GetComponent<GUIText>().text = "Loading Scores";
        Name.text = "Loading";
        Score.text = "Scores";


        WWW hs_get_name = new WWW(hsName);

        yield return hs_get_name;

        
        WWW hs_get_score = new WWW(hsScore);

        yield return hs_get_score;
        
        if (hs_get_name.error != null /*|| hs_get_score != null*/)
        {
            Debug.Log("There was an error getting the names: " + hs_get_name.error);
           // Debug.Log("There was an error getting the scores: " + hs_get_score.error);

        }
        else
        {
            //gameObject.GetComponent<GUIText>().text = hs_get.text; // this is a GUIText that will display the scores in game.
            Name.text = hs_get_name.text;
            Score.text = hs_get_score.text;
           // TextFormat(hs_get.text);
            //Debug.Log(hs_get.text);
        }
    }


    IEnumerator GetMyScores()
    {
        //gameObject.GetComponent<GUIText>().text = "Loading Scores";
        Name.text = "Loading";
        Score.text = "Scores";

        string getName = hsNameMy + "mac=" + GetMac();//SystemInfo.deviceUniqueIdentifier;
        WWW hs_get_name = new WWW(getName);
        yield return hs_get_name;


        string getScore = hsScoreMy + "mac=" + GetMac();//SystemInfo.deviceUniqueIdentifier;
        WWW hs_get_score = new WWW(getScore);
        yield return hs_get_score;

        if (hs_get_name.error != null /*|| hs_get_score != null*/)
        {
            Debug.Log("There was an error getting the names: " + hs_get_name.error);
            Name.text = hs_get_name.error;
            // Debug.Log("There was an error getting the scores: " + hs_get_score.error);

        }
        else
        {
            //gameObject.GetComponent<GUIText>().text = hs_get.text; // this is a GUIText that will display the scores in game.
            Name.text = hs_get_name.text;
            Score.text = hs_get_score.text;
            // TextFormat(hs_get.text);
            //Debug.Log(hs_get.text);
        }
    }

    IEnumerator GetNameScores(string inputName)
    {
        //gameObject.GetComponent<GUIText>().text = "Loading Scores";
        Name.text = "Loading";
        Score.text = "Scores";

        string getName = hsNameName + "Gracz=" + inputName;
        WWW hs_get_name = new WWW(getName);
        yield return hs_get_name;


        string getScore = hsScoreName + "Gracz=" + inputName;
        WWW hs_get_score = new WWW(getScore);
        yield return hs_get_score;

        Debug.Log(getName+" "+ getScore);

        if (hs_get_name.error != null /*|| hs_get_score != null*/)
        {
            Debug.Log("There was an error getting the names: " + hs_get_name.error);
            Name.text = hs_get_name.error;
            // Debug.Log("There was an error getting the scores: " + hs_get_score.error);

        }
        else
        {
            //gameObject.GetComponent<GUIText>().text = hs_get.text; // this is a GUIText that will display the scores in game.
            Name.text = hs_get_name.text;
            Score.text = hs_get_score.text;
            // TextFormat(hs_get.text);
            //Debug.Log(hs_get.text);
        }
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