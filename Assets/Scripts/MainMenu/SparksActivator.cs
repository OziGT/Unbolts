using UnityEngine;
using System.Collections;

public class SparksActivator : MonoBehaviour
{
    public ParticleSystem sparks;
    bool played = false;
    Transform transform;
    //public AdMobBanner ad;
	void Start ()
    {
        transform = GetComponent<Transform>();
	}
    
	void Update ()
    {
        if(transform.localPosition.y<-284 && !played)
        {
            sparks.Play();
            //ad.RequestBanner();
            played = true;
            
        }
	}
    
    public void Play()
    {
        sparks.Play();
        //ad.RequestBanner();
    }
}
