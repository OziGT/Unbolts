using UnityEngine;
using System.Collections;

public class SparksScript : MonoBehaviour
{
    ParticleSystem spark;
	// Use this for initialization
	void Start ()
    {
        spark = GetComponent<ParticleSystem>();
        spark.enableEmission = true;

    }

    // Update is called once per frame
    void Update ()
    {

    }
    
}
