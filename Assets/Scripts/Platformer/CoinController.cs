using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public ScoreController score;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            int s = score.IncreaseScore();
            Debug.Log("The new score is " + s);
            Destroy(gameObject);
        }
    }

}
