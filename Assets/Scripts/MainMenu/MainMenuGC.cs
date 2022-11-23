using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuGC : MonoBehaviour {

    GameObject HSS;
    public Canvas canvas;
    public GameObject loadingScreen;
    void Start ()
    {
        HSS = Resources.Load<GameObject>("UI/HighScore");
    }
	
	void Update ()
    {

        
	}
    public void Play()
    {
        loadingScreen.active = true;
        SceneManager.LoadSceneAsync("DevScrew");
        
    }
    public void EnableHS()
    {
        GameObject HSs = Instantiate(HSS) as GameObject;
        HSs.transform.SetParent(canvas.transform,false);
    }


}
