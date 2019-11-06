using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject loadingtxt;
    void Start()
    {
        loadingtxt.SetActive(false);
    }
	public void Play()
	{
        loadingtxt.SetActive(true);
		SceneManager.LoadScene ("MainScene");
	}
	public void Quit()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}
}

