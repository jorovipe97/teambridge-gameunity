using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWallsController : MonoBehaviour {

    public ActiveAllWalls LeftCoopWalls;
    public ActiveAllWalls CenterCoopWalls;
    public ActiveAllWalls RightCoopWalls;

    /// <summary>
    /// Called when the active region changes in the teambridge-cv module
    /// </summary>
    /// <param name="msg"></param>
	public void OnActiveRegionReceive(OscMessage msg)
    {
        // Gets the active region
        OSCReceiveCVInfo.ActiveRegion activeRegion = (OSCReceiveCVInfo.ActiveRegion) msg.GetInt(0);

        switch (activeRegion)
        {
            // Enables the left wall
            case OSCReceiveCVInfo.ActiveRegion.left:
                LeftCoopWalls.ActiveWalls();
                CenterCoopWalls.DisableWalls();
                RightCoopWalls.DisableWalls();
                break;
            // Enables the center wall
            case OSCReceiveCVInfo.ActiveRegion.center:
                LeftCoopWalls.DisableWalls();
                CenterCoopWalls.ActiveWalls();
                RightCoopWalls.DisableWalls();
                break;

            // Enables the right walls
            case OSCReceiveCVInfo.ActiveRegion.right:
                LeftCoopWalls.DisableWalls();
                CenterCoopWalls.DisableWalls();
                RightCoopWalls.ActiveWalls();
                break;

            // Disables all the walls if there are no one in the camera
            case OSCReceiveCVInfo.ActiveRegion.nothing:
                LeftCoopWalls.DisableWalls();
                CenterCoopWalls.DisableWalls();
                RightCoopWalls.DisableWalls();
                break;

            // By default disable all the walls
            default:
                LeftCoopWalls.DisableWalls();
                CenterCoopWalls.DisableWalls();
                RightCoopWalls.DisableWalls();
                break;
        }
    }
}
