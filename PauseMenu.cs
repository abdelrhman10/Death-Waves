using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;
	public GameObject PauseMenuUI;
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (GameIsPaused)
				Resume ();
			else
				Pause ();
		}
	}
	public void Resume()
	{
		PauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	void Pause()
	{
		PauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	public void ToMainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
	public void Quit()
	{
		Application.Quit ();
		Debug.Log ("quit");
	}
}

