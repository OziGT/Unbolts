using UnityEngine;
using System.Collections;

public class OpenURL : MonoBehaviour


{
    public enum LinkType
    {
        Twitter,
        GameStore
    }
    public LinkType linkType;
    public void GoToURL()
    {
        if(linkType==LinkType.Twitter)
        {
            Application.OpenURL("https://twitter.com/Ozi_stuff");
        }
        else if(linkType==LinkType.GameStore)
        {
            Application.OpenURL("http://play.google.com/store/dev?id=7068801529351286085");
        }
    }
}
