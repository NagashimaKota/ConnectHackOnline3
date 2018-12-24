using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("main");
    }

    public void EndScene()
    {
        SceneManager.LoadScene("END");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
