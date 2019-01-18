using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

[System.Serializable]
public class Data
{
	public string name;
	public int score;
};

public class DataManager : MonoBehaviour 
{
	static public List<Data> dataStorage = new List<Data>();

	static public string userName;

	static public void PassNewData(int score)
	{
		Data d = new Data ();; 
		d.name = userName;
		d.score = score;
		dataStorage.Add (d);
	}

	static public int GetDataStorageSize()
	{
		return dataStorage.Count;
	}

	static public string GetDataName(int i)
	{
		return dataStorage[i].name;
	}

	static public int GetDataScore(int i)
	{
		return dataStorage[i].score;
	}


}
