using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public int ActualScore = 0;
    // This is the min scored needed for win a match
    public int MinScoreForWin = 3;

    /// <summary>
    /// Increases the scores
    /// </summary>
    /// <returns>The score after the increase</returns>
	public int IncreaseScore()
    {
        ActualScore++;
        return ActualScore;
    }
	
}
