using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCscript : MonoBehaviour {

    public bool received;
    public bool card1;
    public bool card2;
    public bool card3;
    public bool card4;
    public bool card5;
    public move moveScript1;
    public string[] dialogue1;
    public string[] dialogue2;
    public string[] dialogue3;
    public string[] dialogue4;
    public string[] dialogue5;

    public int cardsReceived;
    public bool doneTalking;
    public GameManager controller;

    public int roomNumber;

    // Use this for initialization
    void Start () {
        received = false;
        card1 = false;
        card2 = false;
        card3 = false;
        card4 = false;
        card5 = false;
        cardsReceived = 0;
        doneTalking = false;

        if (SceneManager.GetActiveScene().name == "convo") {
            roomNumber = 1;
        }
        else if (SceneManager.GetActiveScene().name == "convo2") {
            roomNumber = 2;
        }
        else if (SceneManager.GetActiveScene().name == "convo3") {
            roomNumber = 3;
        }

        controller = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        controller.numCorrects = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && received) {
            cardsReceived++;
            Debug.Log(cardsReceived);
            if (roomNumber == 1) {
                if (card1) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue1);
                    controller.numCorrects++;
                    card1 = false;
                }
                else if (card2) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue2);
                    controller.numCorrects++;
                    card2 = false;
                }
                else if (card3) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue3);
                    controller.numCorrects--;
                    card3 = false;
                }
            }
            else if (roomNumber == 2) {
                if (card1) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue1);
                    controller.numCorrects--;
                    card1 = false;
                }
                else if (card2) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue2);
                    controller.numCorrects--;
                    card2 = false;
                }
                else if (card3) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue3);
                    controller.numCorrects++;
                    card3 = false;
                }
                else if (card4) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue4);
                    controller.numCorrects++;
                    card4 = false;
                }
            }
            else if (roomNumber == 3) {
                if (card1) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue1);
                    controller.numCorrects--;
                    card1 = false;
                }
                else if (card2) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue2);
                    controller.numCorrects--;
                    card2 = false;
                }
                else if (card3) {
                    Debug.Log("sending dialogue");
                    Dialogue.instance.PlayDialogue(dialogue3);
                    controller.numCorrects++;
                    card3 = false;
                }
                else if (card4) {
                    Debug.Log("sending dialogue");
                    if (GameObject.Find("card_5")) {
                        Dialogue.instance.PlayDialogue(dialogue4);
                        controller.numCorrects++;
                    }
                    else {
                        Dialogue.instance.PlayDialogue(dialogue5);
                        controller.numCorrects--;
                    }
                    card4 = false;
                }
                else if (card5) {
                    Debug.Log("sending dialogue");
                    if (GameObject.Find("card_4")) {
                        Dialogue.instance.PlayDialogue(dialogue4);
                        controller.numCorrects++;
                    }
                    else {
                        Dialogue.instance.PlayDialogue(dialogue5);
                        controller.numCorrects--;
                    }
                    card5 = false;
                }
            }

            if (cardsReceived > 1) {
                doneTalking = true;
                if (roomNumber == 1) {
                    if (controller.numCorrects > 1) {
                        controller.playerLevel = 1;
                    }
                    else if (controller.numCorrects <= 0) {
                        controller.playerLevel = 0;
                    }
                }
                else if (roomNumber == 2) {
                    if (controller.numCorrects > 1) {
                        controller.playerLevel = 2;
                    }
                    else if (controller.numCorrects <= 0) {
                        controller.playerLevel = 1;
                    }
                }
                else {
                    if (controller.numCorrects > 1) {
                        controller.playerLevel = 3;
                    }
                    else if (controller.numCorrects <= 0) {
                        controller.playerLevel = 2;
                    }
                }
                //if (controller.numCorrects > 1) {
                //    controller.playerLevel++;
                //}
                //else if (controller.numCorrects <= 0) {
                //    controller.playerLevel--;
                //}
            }

            received = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "card") {
            received = true;
            if (!doneTalking) {
                if (other.name == "card") {
                    Debug.Log("card1");
                    card1 = true;
                }
                else if (other.name == "card_2") {
                    Debug.Log("card2");
                    card2 = true;
                }
                else if (other.name == "card_3") {
                    Debug.Log("card3");
                    card3 = true;
                }
                else if (other.name == "card_4") {
                    card4 = true;
                }
                else if (other.name == "card_5") {
                    card5 = true;
                }
            }
        }
    }
}