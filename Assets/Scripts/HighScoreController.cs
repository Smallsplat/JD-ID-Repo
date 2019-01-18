using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

    HUDController hc;

    void Start () {
        GameObject hcgo = GameObject.Find("HUD Controller");
        hc = hcgo.GetComponent<HUDController>();

        hc.AddItemToScoreboard(gameObject);
    }
}