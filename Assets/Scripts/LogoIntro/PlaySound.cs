using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlaySound : MonoBehaviour
{
    public AudioSource[] audio;

	void Start ()
    {
        audio = GetComponents<AudioSource>();
	}
    
    public void PlaySmallDrop(int i)
    {
        audio[i].Play();
    }
    
    public void ChangeLevel()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
