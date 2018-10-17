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
        if (SceneManager.GetActiveScene().name == "main") {
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
        //StartCoroutine(WaitForAnim());
        //RestartGame();
    }

    // Update is called once per frame
    void Update () {

        //gameTimer -= Time.deltaTime;
        //if (gameTimer < 0) {
        //    GameOver();
        //    //gameTimer = 999;
        //    //load cutscene once
        //}

	    if (sceneTransitionTimer > 0) {
            sceneTransitionTimer -= Time.deltaTime;
            if (sceneTransitionTimer <= 0) {
                RestartScene();
            }
        }
        //***remember to put here the number of the last scene if you add more!!***
        if (SceneManager.GetActiveScene().buildIndex == 9) {
            //gameTimer = 999;
            //StartCoroutine(WaitForAnim());
            GameObject theEnd = GameObject.Find("sprite_166");
            string lastFrame = theEnd.GetComponent<SpriteRenderer>().sprite.name;
            if (lastFrame == "sprite_201") {
                //StartCoroutine(WaitForAnim());
                Debug.Log("restarting");
                //SetupGame();
                //GenScenes();
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
        //gameTimer = gameTimerFull;
        //scenes = SceneManager.sceneCountInBuildSettings;
        //for (int i = 0; i < scenes; i++) {
            //sceneSelection.Add(i);
        //}
        GenScenes();
        //SelectScene();
        boardScript = GetComponent<BoardManager>();
        RestartScene();
        SceneManager.LoadScene("main");
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

    //IEnumerator WaitForAnim() {
        //yield return new WaitForSeconds(20f);
        //RestartGame();
    //}
}
