using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour {

    void Start ()
    {
        StartCoroutine(DestroyText());
	}

    IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
