using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TeamBridgeEvents : UnityEvent<OscMessage>
{
}

// This is the OSC receiver AKA: The server
public class OSCReceiveCVInfo : MonoBehaviour {

    public OSC oscObject;
    public TeamBridgeEvents onActiveRegionReceived;
    public TeamBridgeEvents onImageReceived;

    // Use this for initialization
    void Start () {
        // By default this is false, and it is ignored in android and iOS
        Application.runInBackground = true;
        oscObject.SetAddressHandler("/teambridge/activeregion", OnActiveRegionReceivedCallback);
        oscObject.SetAddressHandler("/teambridge/img", OnImageReceivedCallback);
    }

    void OnActiveRegionReceivedCallback(OscMessage message)
    {
        onActiveRegionReceived.Invoke(message);
    }

    void OnImageReceivedCallback(OscMessage message)
    {
        onImageReceived.Invoke(message);
    }

    // Enums can be nested inside a class in c#
    // Enums are by default serialized by unity
    public enum ActiveRegion : sbyte
    {
        nothing = -1,
        left = 0,
        center = 1,
        right = 2
    }

}
