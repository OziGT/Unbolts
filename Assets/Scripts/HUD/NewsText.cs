using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewsText : MonoBehaviour
{
    Text text;
    RectTransform rect;
    public string newsURL = "http://ozi.webd.pl/screw/news.php";
    Vector3 startPos;
    void Start ()
    {
        text = GetComponent<Text>();
        rect = GetComponent<RectTransform>();
        StartCoroutine(News());
        startPos = rect.localPosition;
    }
	
    
    void Update ()
    {
        
        rect.localPosition -= new Vector3(120 * Time.deltaTime, 0, 0);
        if (rect.localPosition.x < -rect.sizeDelta.x)
        {
            rect.localPosition = startPos;
        }
        
    }
    IEnumerator News()
    {
        text.text = "Loading News";

        WWW hs_get_news = new WWW(newsURL);

        yield return hs_get_news;


        

        if (hs_get_news.error != null)
        {
            Debug.Log("There was an error getting the names: " + hs_get_news.error);

        }
        else
        {
           text.text = hs_get_news.text;
        }
    }
}
