﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoolGuy : MonoBehaviour {

	//private GameObject coolTalk;		//text box? maybe not necessary
	//private Text coolText;
    public Text theText;
    private GameObject thePlayer;
    private float distance;
    //private GameObject NPC;
    public bool isRight = true;
    private Player playerMove;
    public string[] dialogue;
    public bool talkedTo = false;
    public bool canFlip = true;
    public bool playerHoldingCard;
    public move [] cards;


    void Start () {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerMove = thePlayer.GetComponent<Player>();
        playerHoldingCard = false;
	}

	void Update () {
        distance = Vector2.Distance(this.transform.position, thePlayer.transform.position);
        if (distance < 1.8f) {
            if (thePlayer.transform.position.x < this.transform.position.x && isRight) {
                flip();
            }
            else if (thePlayer.transform.position.x > this.transform.position.x && !isRight) {
                flip();
            }

            for (int i = 0; i < cards.Length; i++) {
                if (!cards[i].NotClicked) {
                    playerHoldingCard = true;
                    playerMove.holdingCard = true;
                    Debug.Log("THEY ARE HOLDING A CARD");
                }
                else {
                    Debug.Log("boo");
                }
            }

            //if (!card.clicked) {
            //    playerHoldingCard = true;
            //    Debug.Log("card is clicked");
            //}
            //else {
            //    Debug.Log("card is NOT clicked");
            //}

            //if (Input.GetButtonDown("Fire1")) {
            //    //thePlayer.GetComponent<Animator>().SetTrigger("seedieStop");
            //    //if (Dialogue.instance.IsTalking() == false) {
            //    //    //Debug.Log("sending dialogue");
            //    //    //Dialogue.instance.PlayDialogue(dialogue);
            //    //    talkedTo = true;
            //    //    if (SceneManager.GetActiveScene().name == "main") {
            //    //        SceneManager.LoadScene("convo");
            //    //    }
            //    //    else if (SceneManager.GetActiveScene().name == "room2") {
            //    //        SceneManager.LoadScene("convo2");
            //    //    }
            //    //    else if (SceneManager.GetActiveScene().name == "room3") {
            //    //        SceneManager.LoadScene("convo3");
            //    //    }
            //    //    else if (SceneManager.GetActiveScene().name == "room4") {
            //    //        SceneManager.LoadScene("convo");
            //    //    }
            //    //    else if (SceneManager.GetActiveScene().name == "room5") {
            //    //        SceneManager.LoadScene("convo2");
            //    //    }
            //    //    else if (SceneManager.GetActiveScene().name == "room6") {
            //    //        SceneManager.LoadScene("convo3");
            //    //    }
            //    //    else if (SceneManager.GetActiveScene().name == "room7") {
            //    //        SceneManager.LoadScene("convo");
            //    //    }
            //    //    else if (SceneManager.GetActiveScene().name == "room8") {
            //    //        SceneManager.LoadScene("convo2");
            //    //    }
            //    //    else if (SceneManager.GetActiveScene().name == "room9") {
            //    //        SceneManager.LoadScene("convo3");
            //    //    }
            //    //}
            //}
        }
    }

    private void OnMouseDown() {
        Debug.Log("mouse down");
        thePlayer.GetComponent<Animator>().SetTrigger("seedieStop");
        if (Dialogue.instance.IsTalking() == false && playerHoldingCard) {
            //Debug.Log("sending dialogue");
            //Dialogue.instance.PlayDialogue(dialogue);
            talkedTo = true;
            if (SceneManager.GetActiveScene().name == "main") {
                SceneManager.LoadScene("convo");
            }
            else if (SceneManager.GetActiveScene().name == "room2") {
                SceneManager.LoadScene("convo2");
            }
            else if (SceneManager.GetActiveScene().name == "room3") {
                SceneManager.LoadScene("convo3");
            }
            else if (SceneManager.GetActiveScene().name == "room4") {
                SceneManager.LoadScene("convo");
            }
            else if (SceneManager.GetActiveScene().name == "room5") {
                SceneManager.LoadScene("convo2");
            }
            else if (SceneManager.GetActiveScene().name == "room6") {
                SceneManager.LoadScene("convo3");
            }
            else if (SceneManager.GetActiveScene().name == "room7") {
                SceneManager.LoadScene("convo");
            }
            else if (SceneManager.GetActiveScene().name == "room8") {
                SceneManager.LoadScene("convo2");
            }
            else if (SceneManager.GetActiveScene().name == "room9") {
                SceneManager.LoadScene("convo3");
            }
        }
    }

    void flip() {
        if (canFlip) {
            isRight = !isRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
