using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingMenu : MonoBehaviour
{
	public AudioMixer audiomixer;
	public GameObject Soundtrack;

	public Dropdown resolutiondropdown;

	Resolution[]resolutions;
	void Start()
	{
		resolutions = Screen.resolutions;
		Instantiate (Soundtrack);
		resolutiondropdown.ClearOptions ();
		int currentresolutionindex = 0;
		List<string> options=new List<string>();
		for (int i = 0; i < resolutions.Length; i++) 
		{
			string option = resolutions [i].width + "x" + resolutions [i].height;
			options.Add (option);
			if (resolutions [i].width == Screen.currentResolution.width &&
			   resolutions [i].height == Screen.currentResolution.height) 
			{
				currentresolutionindex = i;
			}
		}
		resolutiondropdown.AddOptions (options);
		resolutiondropdown.value = currentresolutionindex;
		resolutiondropdown.RefreshShownValue ();
	}

	public void Volume(float volume)
		{
			audiomixer.SetFloat ("volume", volume);
		}
	public void setquality(int qualityindex)
	{
		QualitySettings.SetQualityLevel (qualityindex);
	}
	public void ToggleFullScreen(bool isFull)
	{
		Screen.fullScreen = isFull;
	}
	public void changeresolution(int resolutionindex)
	{
		Resolution resolution = resolutions [resolutionindex];
		Screen.SetResolution (resolution.width, resolution.height,Screen.fullScreen);
	}
}

