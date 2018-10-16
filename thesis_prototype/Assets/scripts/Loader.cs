using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    //public GameObject[] gameManagers;
    public GameObject gameManager;

	// Use this for initialization
	void Awake () {
		if (GameManager.instance == null) {
			Instantiate(gameManager);
            //Debug.Log(SceneManager.sceneCountInBuildSettings);
		}	
	}
}
