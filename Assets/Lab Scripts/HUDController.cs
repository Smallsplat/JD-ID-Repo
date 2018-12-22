using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public Text timeText;
	float startTime;

	public Text countText;
	private int count;

	public Image healthBar;

	public GameObject Star;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		float t = Time.time - startTime;
		string minutes = ((int)t / 60).ToString ("00");
		string seconds = ((int)t % 60).ToString ("00");
		timeText.text = minutes + ":" + seconds;

		healthBar.fillAmount -= 0.02f * Time.deltaTime;

		if (count >= 7) 
		{
			Star.SetActive (true);
		} 
		else 
		{
			Star.SetActive (false);
		}
	}

	public void IncrementCount() {
		count++;
		countText.text = count.ToString ();
	}

	public void ReduceCount() {
		count--;
		countText.text = count.ToString ();
	}

	public void GameSpeed(float sliderVal) {
		Time.timeScale = sliderVal;
	}

}