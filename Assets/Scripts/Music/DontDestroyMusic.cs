using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class DontDestroyMusic : MonoBehaviour
{

    static DontDestroyMusic musicInstance;
    public GameObject gb;
    bool last;
    void Start()
    {


    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && !gb.activeSelf)
        {
            gb.SetActive(true);

        }
        else if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            gb.SetActive(false);

        }



    }

}
