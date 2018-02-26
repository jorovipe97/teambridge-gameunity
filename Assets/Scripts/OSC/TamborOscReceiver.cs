using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TamborEvents : UnityEvent<OscMessage>
{
}

public class TamborOscReceiver : MonoBehaviour {

    public OSC oscObject;
    public TamborEvents onTamborStatusReceived;
    public TamborEvents onCorrectHit;

	// Use this for initialization
	void Start () {
        oscObject.SetAddressHandler("/tambor/status", OnTamborStatusReceivedCallback);
        oscObject.SetAddressHandler("/tambor/correct_hits_counter", OnCorrectHitCallback);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTamborStatusReceivedCallback(OscMessage m)
    {
        onTamborStatusReceived.Invoke(m);
    }

    void OnCorrectHitCallback(OscMessage m)
    {
        onCorrectHit.Invoke(m);

        /*int countHits = m.GetInt(0);
        Debug.Log("User has correctly hit " + countHits.ToString() + " times the drum!!!");*/
    }
}
