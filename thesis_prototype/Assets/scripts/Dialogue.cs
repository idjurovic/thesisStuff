using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

    public static Dialogue instance;
    private string[] messages;
    private int currentMessageIndex;
    private DialogueRenderer dRenderer;
    [SerializeField]
    private AudioSource diaSource;
    [SerializeField]
    private AudioClip firstDia;

	// Use this for initialization
	void Start () {
        instance = this;
        dRenderer = GetComponent<DialogueRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && dRenderer.IsBoxActive()) {
            if (HasNext()) {
                NextMessage();
                ShowCurrentMessage();
            }
            else {
                dRenderer.TakeOffScreen();
            }
        }
    }

    string GetCurrentMessage() {
        string theMessage = messages[currentMessageIndex];
        return theMessage;
    }

    bool HasNext () {
        return messages != null && currentMessageIndex+1 < messages.Length;
    }

    void NextMessage() {
        currentMessageIndex++;
    }

    public void PlayDialogue(string[] array) {
        messages = array;
        currentMessageIndex = 0;
        diaSource.PlayOneShot(firstDia);
        ShowCurrentMessage();
    }

    void ShowCurrentMessage() {
        string currentString = GetCurrentMessage();
        dRenderer.PutOnScreen(currentString);
    }

    public bool IsTalking() {
        return dRenderer.IsBoxActive();
    }
}
