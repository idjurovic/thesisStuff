using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueRenderer : MonoBehaviour {

    private Animator animator;
    private Text text;
    private CanvasGroup canvasGroup;
    [SerializeField]
    private AudioSource dSource;
    [SerializeField]
    private AudioClip dSound;
    [SerializeField]
    private AudioClip inSound;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        text = GetComponentInChildren<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
	}

    public void PutOnScreen(string message) {
        animator.Play("In");
        dSource.PlayOneShot(dSound);
        text.text = message;
    }

    public void TakeOffScreen() {
        animator.Play("Out");
        dSource.PlayOneShot(inSound);
    }

    public bool IsBoxActive() {
        return canvasGroup.alpha > 0.5f;
    }
}
