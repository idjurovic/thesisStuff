using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour {

    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        coroutine = Wait(5f);
        StartCoroutine(coroutine);
	}
	
	private IEnumerator Wait (float waitTime) {
        yield return new WaitForSeconds(waitTime);
        if (SceneManager.GetActiveScene().name == "goodEnding") {
            SceneManager.LoadScene(Random.Range(1, 8));
        }
        else if (SceneManager.GetActiveScene().name == "normalEnd") {
            SceneManager.LoadScene(Random.Range(0, 8));
        }
        else {
            SceneManager.LoadScene(0);
        }
    }
}
