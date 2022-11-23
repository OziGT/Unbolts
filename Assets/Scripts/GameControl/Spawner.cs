using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    GCscrew gCscrew;

    GameObject[] screwPrefabs;

	void Start ()
    {
        screwPrefabs= Resources.LoadAll<GameObject>("Prefabs");
        gCscrew = GetComponent<GCscrew>();
	}
	
	void Update ()
    {
	    if(((gCscrew.pass)||(gCscrew.fail))&&(gCscrew.xBonus!=2))
        {
            if (gCscrew.bonus != 5)
            {
                GameObject screw = Instantiate(screwPrefabs[Mathf.RoundToInt(Random.Range(0, 2))]) as GameObject;
                screw.transform.position = new Vector3(172, 0, 0);
            }
            
            else
            {
                GameObject screw = Instantiate(screwPrefabs[Mathf.RoundToInt(Random.Range(2, 4))]) as GameObject;
                screw.transform.position = new Vector3(172, 0, 0);

            }
        }
        if (((gCscrew.pass) || (gCscrew.fail)) && (gCscrew.xBonus == 2))
        {
            GameObject screw = Instantiate(screwPrefabs[Mathf.RoundToInt(Random.Range(2, 4))]) as GameObject;
            screw.transform.position = new Vector3(172, 0, 0);
        }
    }
}
