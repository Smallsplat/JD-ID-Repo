using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesCollider : MonoBehaviour {

	CollectablesController cc;

	private AudioSource source;
	[SerializeField] private AudioClip clip;

	void Start ()
	{
		GameObject ccgo = GameObject.Find ("Collectables Controller");
		cc = ccgo.GetComponent<CollectablesController>();
	}
		
	void OnTriggerEnter (Collider col) 
	{
		Debug.Log (gameObject.name + "hit");
		source = col.GetComponent<AudioSource> ();
		source.PlayOneShot(clip);

		cc.IncrementCount(gameObject);

		Destroy (gameObject);
	}
}