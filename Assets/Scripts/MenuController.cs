using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour 
{
	public AudioSource musicSource;
	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject musicSlider;

	void update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Debug.Log ("Pressed Escape");
			optionsMenu.gameObject.SetActive (true);
		}
	}
	
	public void PlayGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	public void PlayMusic()
	{
		if (musicSource.isPlaying) 
		{
			musicSource.Pause ();
			Debug.Log ("Music is not playing");
		} 
		else 
		{
			musicSource.Play ();
			Debug.Log ("Music is playing");
		}
			
	}
		
	public void SetFullscreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}

	public void MusicVolume(float sliderVal) {
		musicSource.volume = sliderVal;
	}
}

