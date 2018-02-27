using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLostChecker : MonoBehaviour {

    public GameObject winMsg;
    public GameObject loseMsg;
    public ScoreController score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag.Equals("EndChecker"))
        {
            // Ask if player has win the game
            if(score.HasPlayerWin())
            {
                // Shows the win message
                winMsg.SetActive(true);
            }
            else
            {
                // Shows the lose message
                loseMsg.SetActive(true);
            }
        }
    }
}
