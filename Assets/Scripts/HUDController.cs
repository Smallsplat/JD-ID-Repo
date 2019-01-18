using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour {

    public Text timeText;
    float startTime;

    public Text coinsText;
    private int coins;

    public Text pointsText;
    private int points;

    public Text finalPointsText;
    public int finalPoints;

    public Image healthBar;
    public Transform HUDCanvasLocation;
    public GameObject CoinCollectedText;
    public GameObject HealthCollectedText;
    public GameObject HUDPanel;
    public GameObject EndPanel;
    public GameObject optionsMenu;
    public AudioSource musicSource;
    public bool escapeIsTrue = false;
    public bool CanRemoveStepPoints = true;
    public Transform UICenter;

    public GameObject Playerctrl;

    public UserScoreData[] ud;
    public GameObject scrollPrefab;
    public GameObject scrollContent;
    public GameObject addedItem;

	public CollectablesController cc;

	bool endGame = false;

    void Start() {
        //Setting up Default Values
        Time.timeScale = 1;
        startTime = Time.time;
        HUDPanel.gameObject.SetActive(true);
        EndPanel.gameObject.SetActive(false);
    }

    void Update() {

        //Time
		float t = 15 - (Time.time - startTime);
        string minutes = ((int)t / 60).ToString("00");
        string seconds = ((int)t % 60).ToString("00");
        timeText.text = minutes + ":" + seconds;

        //Losing health
        healthBar.fillAmount -= 0.02f * Time.deltaTime;

        if (points <= 1)
        {
            points = 1;
        }

        //End game detectors
		if (healthBar.fillAmount <= 0 && !endGame)
        {
            GameEnd();
			endGame = true;

        }

		if (t <= 0 && !endGame)
        {
            GameEnd();
			endGame = true;

        }


        //In-game options with Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapeIsTrue == false)
            {
                Debug.Log("Pressed Escape");
                Time.timeScale = 0;
                optionsMenu.gameObject.SetActive(true);
                escapeIsTrue = true;
            }

            else if (escapeIsTrue == true)
            {
                Debug.Log("Pressed Escape");
                Time.timeScale = 1;
                optionsMenu.gameObject.SetActive(false);
                escapeIsTrue = false;
            }
        }

    }

    //Turning options off Button
    public void OptionsMenuOff()
    {
        Time.timeScale = 1;
        optionsMenu.gameObject.SetActive(false);
        escapeIsTrue = false;
    }


    //Picking up a coin
    public void IncrementCount() {
        //Spawning Animations
        GameObject CurrentCoinText = Instantiate(CoinCollectedText, UICenter.position, Quaternion.identity);
        CurrentCoinText.transform.SetParent(HUDCanvasLocation);
        GameObject CurrentHealthText = Instantiate(HealthCollectedText, UICenter.position, Quaternion.identity);
        CurrentHealthText.transform.SetParent(HUDCanvasLocation);

        //Adding Values to Varaibles
        Debug.Log("Coins Points Awarded");
        coins++;
        coinsText.text = coins.ToString();
        healthBar.fillAmount = healthBar.fillAmount + 0.1f;
        points = points + 10;
        pointsText.text = points.ToString();
    }

    //Gain points visiting locations
    public void LocationPoints()
    {
        Debug.Log("Place Points Awarded");
        healthBar.fillAmount = healthBar.fillAmount + 0.25f;
        points = points + 100;
        pointsText.text = points.ToString();
    }

    //Remove points while walking
    public void DecreaseCountSteps()
    {
        if (CanRemoveStepPoints == true)
        {
            Debug.Log("Removing Step Points");
            points = points - 1;
            pointsText.text = points.ToString();
            CanRemoveStepPoints = false;
            StartCoroutine(StepPointCooldown());
        }
    }
    IEnumerator StepPointCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        CanRemoveStepPoints = true;
    }

    //Spawning the end menu
    public void GameEnd()
    {
        finalPoints = points;
        finalPointsText.text = finalPoints.ToString();
        Time.timeScale = 0;
        HUDPanel.gameObject.SetActive(false);
        EndPanel.gameObject.SetActive(true);
        cc.SubmitUserInformation();
        AddItemToScoreboard ();
    }

    //Adding End Menu stuff?
    public void AddItemToScoreboard()
    {
        Debug.Log("activate");
        for (int i = 0; i < DataManager.GetDataStorageSize (); i++)
		{
            Debug.Log("Inset New Data type" + i);

            addedItem = Instantiate(scrollPrefab);
			addedItem.transform.SetParent(scrollContent.transform);
			addedItem.transform.localPosition = Vector3.zero;
			addedItem.transform.localScale = Vector3.one;

			addedItem.transform.Find ("Username (Text)").GetComponent<Text> ().text = DataManager.GetDataName (i);
			addedItem.transform.Find ("User Score (Text)").GetComponent<Text> ().text = DataManager.GetDataScore(i).ToString();
		} 
    }
}