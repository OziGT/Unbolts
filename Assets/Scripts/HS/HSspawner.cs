using UnityEngine;
using System.Collections;

public class HSspawner : MonoBehaviour
{

    GameObject HSS,TUT;
    public bool SaveAtStart;
    public Canvas canvas;
    public GameObject HS;
    void Start ()
    {
       // HSS = Resources.Load<GameObject>("UI/HighScore");
        TUT = Resources.Load<GameObject>("UI/TutorialUI");

    }

    // Update is called once per frame
    void Update ()
    {
	
	}
    public void EnableHS()
    {
        /*
        GameObject HSs = Instantiate(HSS) as GameObject;
        HSs.transform.SetParent(canvas.transform, false);
        HSs.GetComponent<HSFile>().once = SaveAtStart;
        */
        HS.active = true;
    }
    
    public void EnableTUT()
    {
        GameObject TUt = Instantiate(TUT) as GameObject;
        TUt.transform.SetParent(canvas.transform, false);
    }
}
