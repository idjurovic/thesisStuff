using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightCard : MonoBehaviour {

    public move moveScript;
    public ParticleSystem parti;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!moveScript.correctPos) {
            parti.Play();
        }
	}
}
