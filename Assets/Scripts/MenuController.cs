using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour 
{
	public AudioSource musicSource;
	public GameObject mainMenu;
	public GameObject optionsMenu;
    public GameObject characterMenu;
    public GameObject musicSlider;

    public CollectablesController cc;

    public Text username;

    //Setting the Menu to be default loadup
    void Start()
    {
        optionsMenu.gameObject.SetActive(false);
        characterMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
	
    //Loads into the main game
	public void PlayGame()
	{
        cc.LoadData();
        DataManager.userName = username.text;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

    //Loads into the main Menu
    public void GoToMenu()
    {
        cc.SaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Quits Game
    public void QuitGame()
	{
		Application.Quit ();
	}

    //Plays music
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
	
    //Fullscreen
	public void SetFullscreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}

    //Music Slider
	public void MusicVolume(float sliderVal) {
		musicSource.volume = sliderVal;
	}
}

