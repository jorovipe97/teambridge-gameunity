using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideAfterXSeconds : MonoBehaviour {

    // Time for hide actual object
    [Tooltip("Time for hide the actual object")]
    public int Seconds = 3;

	// Use this for initialization
	void Start () {
        StartCoroutine(Hide());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(Seconds);
        gameObject.SetActive(false);
    }
}
