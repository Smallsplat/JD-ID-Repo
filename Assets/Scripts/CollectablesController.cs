using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CollectablesController : MonoBehaviour 
{
	public CollectablesData[] cd; 

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) 
		{
			Destroy (gameObject);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown ("l")) {
			Debug.Log ("Loading Data...");
			LoadData ();
		} else if (Input.GetKeyDown ("s")) {
			Debug.Log ("Saving Data...");
			SaveData ();
		}
	}


	public void IncrementCount (GameObject go)
	{
		if (go.name.Contains ("Gold Coin")) {
			cd [0].collectableNum++;
		} else if (go.name.Contains ("Golden Goat")) {
			cd[1].collectableNum++;
		}
		OutputCounts ();
	}

	void OutputCounts()
	{
		Debug.Log ("You've Collected: ");
		Debug.Log ("Coins = " + cd[0].collectableNum);
		Debug.Log ("Goat = " + cd[1].collectableNum);
	}

	public void SaveData()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/gameData.dat");
		bf.Serialize (fs, cd);
		fs.Close ();
		Debug.Log ("Data Saved.");
	}

	public void LoadData()
	{
		if (File.Exists (Application.persistentDataPath + "/gameData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (Application.persistentDataPath + "/gameData.dat", FileMode.Open);
			cd = (CollectablesData[])bf.Deserialize (fs);
			fs.Close ();
			Debug.Log ("Data Loaded.");
		} else 
		{
			Debug.LogError ("File you are trying to load from is missing");
		}

	}		

}
