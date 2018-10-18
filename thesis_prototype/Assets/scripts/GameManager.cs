using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float levelStartDelay = 2f;
    private float sceneTransitionTimer;
    private float transitionTimer;
	public static GameManager instance = null;
	public BoardManager boardScript;
    private GameObject levelImage;      //black curtain
    private bool doingSetup;    //setting up board?
    private int nextScene;
    private int sceneSelectIndex;
    private int scenes;
    //private int scenes = SceneManager.sceneCountinBuildSettings;
    private List<int> sceneSelection = new List<int>();     //list of scene indices?
    //public float gameTimer;
    //public float gameTimerFull = 10f;
    public GameObject startHand;
    public GameObject level1Hand;
    public Camera mainCamera;
    public int playerLevel;
    public int numCorrects;

    // Use this for initialization
    void Awake () {
        //scenes = SceneManager.sceneCountInBuildSettings;
        Application.targetFrameRate = 60;
        if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
        //Cursor.visible = false;
        SetupGame();
        //RestartGame();
        //playerLevel = 0;
    }

    private void OnLevelWasLoaded (int index) {
        InitGame();
    }

	void InitGame() {
        doingSetup = true;
        Debug.Log("doing setup");
        levelImage = GameObject.Find("LevelImage");     //finds curtain in inspector
        levelImage.GetComponent<Image>().CrossFadeAlpha(0.1f, 1f, false);
        Invoke("HideLevelImage", levelStartDelay);
		boardScript.SetupScene();
        //if (SceneManager.GetActiveScene().name == "main") {
        if (playerLevel < 1) {
            Instantiate(startHand, GameObject.FindGameObjectWithTag("MainCamera").transform);
        }
        else {
            Instantiate(level1Hand, GameObject.FindGameObjectWithTag("MainCamera").transform);
        }
	}

    private void HideLevelImage() {
        //levelImage.SetActive(false);
        levelImage.GetComponent<CanvasRenderer>().SetAlpha(0f);
        doingSetup = false;
    }

    public void GameOver() {
        Debug.Log("Game Over");
        //gameTimer = 999;
        SceneManager.LoadScene(9);
        //RestartGame();
    }

    // Update is called once per frame
    void Update () {
	    if (sceneTransitionTimer > 0) {
            sceneTransitionTimer -= Time.deltaTime;
            if (sceneTransitionTimer <= 0) {
                RestartScene();
            }
        }
        //***remember to put here the number of the last scene if you add more!!***
        if (SceneManager.GetActiveScene().buildIndex == 9) {
            GameObject theEnd = GameObject.Find("sprite_166");
            string lastFrame = theEnd.GetComponent<SpriteRenderer>().sprite.name;
            if (lastFrame == "sprite_201") {
                Debug.Log("restarting");
                RestartGame();
                //SceneManager.LoadScene("main");
            }
        }
    }

    public void Restart(float transitionTimer) {
        sceneTransitionTimer = transitionTimer;
    }

    private void RestartScene() {
        levelImage = GameObject.Find("LevelImage");     //finds curtain in inspector
        levelImage.GetComponent<Image>().CrossFadeAlpha(1f, 0.05f, false);

        //sceneSelectIndex = Random.Range(0, sceneSelection.Count-1);
        //nextScene = sceneSelection[sceneSelectIndex];

        //sceneSelection.RemoveAt(sceneSelectIndex);
        //Debug.Log(nextScene);
        SelectScene();
        //SceneManager.LoadScene(nextScene);
    }

    public void SetupGame() {
        GenScenes();
        //SelectScene();
        boardScript = GetComponent<BoardManager>();
        RestartScene();
        SceneManager.LoadScene("main");
        playerLevel = 0;
    }

    void RestartGame() {
        Debug.Log("RestartGame() invoked now");
        SetupGame();
        //SceneManager.LoadScene("main");
    }

    void GenScenes() {
        sceneSelection.Clear();
        scenes = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < scenes; i++) {
            sceneSelection.Add(i);
        }
    }

    void SelectScene() {
        //sceneSelectIndex = Random.Range(0, sceneSelection.Count - 1);
        //nextScene = sceneSelection[sceneSelectIndex];
        //sceneSelection.RemoveAt(sceneSelectIndex);
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
        nextScene++;
    }

    public void ExitConvo() {
        if (playerLevel <= 0) {
            //bad end
            Debug.Log("bad end\n" + numCorrects);
            SceneManager.LoadScene("badEnd");
        }
        //else if (numCorrects > 0 && numCorrects < 2) {
        //    //normal end
        //    Debug.Log("normal end\n" + numCorrects);
        //    SceneManager.LoadScene("normalEnd");
        //}
        else {
            //good end
            Debug.Log("good end\n" + numCorrects);
            //playerLevel++;  //this currently doesn't do anything
            SceneManager.LoadScene("goodEnding");
        }
    }
}
