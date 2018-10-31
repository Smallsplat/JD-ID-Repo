using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesCollider : MonoBehaviour {
	
	private AudioSource source;
	[SerializeField] private AudioClip clip;

	void OnTriggerEnter (Collider col) 
	{
		Debug.Log (gameObject.name + "hit");
		source = col.GetComponent<AudioSource> ();
		source.PlayOneShot(clip);

		Destroy (gameObject);
	}
}
