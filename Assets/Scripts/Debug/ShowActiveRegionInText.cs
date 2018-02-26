using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowActiveRegionInText : MonoBehaviour {

    private Text txt;

	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateActiveRegionInUI(OscMessage msg)
    {
        

        OSCReceiveCVInfo.ActiveRegion activeReg = (OSCReceiveCVInfo.ActiveRegion) msg.GetInt(0);
        string region = "";

        switch (activeReg)
        {
            case OSCReceiveCVInfo.ActiveRegion.nothing:
                region = "Nothing";
                break;
            case OSCReceiveCVInfo.ActiveRegion.left:
                region = "Left";
                break;
            case OSCReceiveCVInfo.ActiveRegion.center:
                region = "Center";
                break;
            case OSCReceiveCVInfo.ActiveRegion.right:
                region = "Right";
                break;
            default:
                region = "Raro";
                break;
        }

        txt.text = region;
    }
}
