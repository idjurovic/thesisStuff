using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {

    //private float restartLevelDelay = 0.5f;
    private Animator animator;
    //private gameObject player;
    private bool isRight = true;
    private float speed;
    private GameObject levelImage;
    private Rigidbody2D rbody;

    [SerializeField]
    private ParticleSystem dustParticles;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioClip walking;

    public bool holdingCard;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        speed = 200f;

        holdingCard = false;
    }

	// Update is called once per frame
    void Update() {
        dustParticles.enableEmission = rbody.velocity.magnitude > 0.1f;
        if (Dialogue.instance.IsTalking()) {
            animator.SetTrigger("seedieStop");
            //rbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else {
            //rbody.constraints = RigidbodyConstraints2D.None;
            //rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            MovementUpdate();
        }
	}

    void flip () {
        isRight = !isRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void MovementUpdate() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(";")) {
            rbody.constraints = RigidbodyConstraints2D.None;
        }
        if (horizontal != 0 || vertical != 0) {
            animator.SetTrigger("seedieWalk");
            if (Time.frameCount % 20 == 0) {
                AudioSource.PlayClipAtPoint(walking, this.transform.position);
            }
            //soundSource.PlayOneShot(walking);
            //StartCoroutine(PlaySF());
            //soundSource.clip = walking;
            //soundSource.Play();
        }
        else {
            animator.SetTrigger("seedieStop");
        }

        rbody.velocity = new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
        if (horizontal > 0 && !isRight) {
            flip();
        }
        else if (horizontal < 0 && isRight) {
            flip();
        }
    }

    IEnumerator PlaySF() {
        //soundSource.clip = walking;
        if (soundSource.isPlaying) {
            soundSource.Stop();
        }
        else {
            soundSource.PlayOneShot(walking);
        }
        //soundSource.PlayOneShot(walking);
        //soundSource.Pause();
        yield return new WaitForSeconds(1f);
        //soundSource.UnPause();
        //Debug.Log("unpaused");
    }
}
