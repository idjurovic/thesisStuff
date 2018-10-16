using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

    public float sceneChange = 0.5f;
    private CoolGuy[] coolguys;
    private GameObject theExit;
    [SerializeField] private ParticleSystem exitPart;
    [SerializeField]
    private AudioSource exitSource;
    [SerializeField]
    private AudioClip exitSound;

    void Start() {
        coolguys = FindObjectsOfType<CoolGuy>();
        exitPart.enableEmission = false;
    }

    void Update() {
        CanExit();
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

    bool CanExit() {
        for(int i = 0; i < coolguys.Length; i++) {
            if (!coolguys[i].talkedTo) {
                return false;
            }
        }
        exitPart.enableEmission = true;
        //exitSource.PlayOneShot(exitSound);
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && CanExit()) {
            //Invoke ("Restart", restartLevelDelay);
            GameManager.instance.Restart(sceneChange);
            other.GetComponent<Player>().enabled = false;
        }
    }
}
