using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public bool NotClicked;
    public bool won;
    public bool correctPos;
    public bool talked;
    public int placementReq;
    private Vector3 startPos;
    public NPCscript talker;
    //public Player playerScript;
    //public CoolGuy npcScript;

	// Use this for initialization
	void Start () {
        NotClicked = true;
        won = false;
        correctPos = false;
        talked = false;
        startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!NotClicked) {
            Vector3 temp = Input.mousePosition;
            temp.z = 10f;
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(temp);
            //playerScript.holdingCard = true;
            //npcScript.playerHoldingCard = true;
        }
        //else {
        //    this.gameObject.transform.position = startPos;
        //    if (playerScript != null) {
        //        //playerScript.holdingCard = false; 
        //    }
        //    if (npcScript != null) {
        //        //npcScript.playerHoldingCard = false;
        //    }
        //}
    }

    private void OnMouseDown() {
        if (!NotClicked) {
            if (won) {
                Debug.Log("yaaaay u won");
            }
            if (talked) {
                if (talker != null && !talker.doneTalking) {
                    Debug.Log("This NPC is now talking...");
                    Destroy(this.gameObject);
                }
            }
            NotClicked = true;
        }
        else {
            NotClicked = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //won = true;
        if (other.tag == "placement" + placementReq) {
            Debug.Log("right pos");
            correctPos = true;
            won = true;
        }
        if (other.tag == "NPC") {
            Debug.Log("pos to talk");
            correctPos = true;
            talked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        won = false;
        correctPos = false;
    }
}
