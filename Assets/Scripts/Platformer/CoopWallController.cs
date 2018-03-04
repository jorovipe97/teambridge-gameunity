using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CoopWallController : MonoBehaviour {

    public Sprite walkableWallSprite;
    public Sprite invisibleWallSprite;

    private SpriteRenderer sr;
    private BoxCollider2D col;

    // By default the wall is not walkable
    private bool isWalkable = false;

    public bool IsWalkable
    {
        get
        {
            return isWalkable;
        }

        set
        {
            isWalkable = value;

            // If it is walkable
            if (isWalkable)
            {
                // Set the walkable sprite to the sprite renderer
                sr.sprite = walkableWallSprite;
                // Enable collider
                col.enabled = true;
            }
            else
            {
                // Set the no-walkable sprite to the sprite renderer
                sr.sprite = invisibleWallSprite;
                // Disable collider
                col.enabled = false;
            }
        }
    }

	// Use this for initialization
	void Awake () {
        // Initializes the sprite renderer
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = invisibleWallSprite;

        col = gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false;
	}
	
    /// <summary>
    /// Toggle wall to make it walkable or not
    /// </summary>
    [ContextMenu("Toggle Walkable")]
	public void ToggleWalkable()
    {
        IsWalkable = !IsWalkable;
    }
}
