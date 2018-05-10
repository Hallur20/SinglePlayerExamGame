using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButtonBehaviour : MonoBehaviour {

    public Button button;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(RestartScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RestartScene()
    {
        if (ControlPlayer.lifes > -1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else
        {
            ControlPlayer.lifes = 3;
            SceneManager.LoadScene("_scene");
        }
        
    }
}
