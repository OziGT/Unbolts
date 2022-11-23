using UnityEngine;
using System.Collections;

public class NewsActivator : MonoBehaviour {

    bool played = false;
    Transform transform;
    public GameObject News,ID;
    public AdMobBanner ad;

    int i = 0;
    void Start()
    {
        ad.RequestBanner();
        transform = GetComponent<Transform>();
    }
    
    void Update()
    {
        if (transform.localPosition.y < -284 && !played)
        {
            StartCoroutine(PlayC());
            played = true;
        }
    }
    
    public void Play()
    {
        News.gameObject.SetActive(true);
        ID.gameObject.SetActive(true);
    }

    IEnumerator PlayC()
    {
        News.gameObject.SetActive(true);
        ID.gameObject.SetActive(true);
        
        //Debug.Log(i++);
        yield return null;
    }
}
