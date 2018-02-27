using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour {

    public Transform player;

    private Vector3 newPos;

	// Use this for initialization
	void Start () {
        newPos = new Vector3(gameObject.transform.position.x, player.position.y, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        newPos.y = player.position.y;
        gameObject.transform.position = newPos;
    }
}
