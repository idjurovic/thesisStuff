using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public int numCorrects;
    public move moveScript1;
    public move moveScript2;
    public move moveScript3;
    List<int> ends = new List<int>();
    public NPCscript NPC;
    public GameManager gameManager;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 3; i++) {
            ends.Add(0);
        }
        numCorrects = 1;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Restart() {
        if (numCorrects <= 0) {
            //bad end
            Debug.Log("bad end\n" + numCorrects);
            SceneManager.LoadScene("badEnd");
        }
        else if (numCorrects > 0 && numCorrects < 2) {
            //normal end
            Debug.Log("normal end\n" + numCorrects);
            SceneManager.LoadScene("normalEnd");
        }
        else {
            //good end
            Debug.Log("good end\n" + numCorrects);
            gameManager.playerLevel++;
            SceneManager.LoadScene("goodEnding");
        }
        //SceneManager.LoadScene("test");
    }
}
