using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HSSpacing : MonoBehaviour
{
    VerticalLayoutGroup vertical;
    public Text text;
    public float textHeight;
    public GameObject nameob, score;
	void Start ()
    {
        vertical = GetComponent<VerticalLayoutGroup>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //vertical.spacing = -text.text.Split('\n').Length * textHeight;
        score.transform.position = new Vector3(
            score.transform.position.x,
            nameob.transform.position.y,
            score.transform.position.z);
    }

    
}
