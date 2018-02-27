using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour {

    [Tooltip("Shortcut for restart the current scene")]
    public KeyCode shortcut = KeyCode.R;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ShortcutRestart(shortcut);
		
	}

    private void ShortcutRestart(KeyCode shortcut)
    {
        if (Input.GetKeyDown(shortcut))
            ResetScene();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
