using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAllWalls : MonoBehaviour {

    private CoopWallController[] childs;

    private void Awake()
    {
        // Get all the childrens
        childs = gameObject.GetComponentsInChildren<CoopWallController>();
    }

    /// <summary>
    /// Makes walkable all children walls 
    /// </summary>
    public void ActiveWalls()
    {
        for (int i = 0; i < childs.Length; i++)
        {
            // Make walkable all childs walls
            childs[i].IsWalkable = true;
        }
    }

    /// <summary>
    /// Makes non-walkable all children walls
    /// </summary>
    public void DisableWalls()
    {
        for (int i = 0; i < childs.Length; i++)
        {
            // Make non walkable all child walls
            childs[i].IsWalkable = false;
        }
    }
	
}
