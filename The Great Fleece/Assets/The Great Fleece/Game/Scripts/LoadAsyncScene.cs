using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadAsyncScene : MonoBehaviour {

    public Scrollbar loadingBar;

	// Use this for initialization
	void Start () {
        StartCoroutine("LoadMainGame");
	}

    IEnumerator LoadMainGame()
    {
        yield return null;

        //load the main scene. I know, its hardcoded, its just a demo
        AsyncOperation operation = SceneManager.LoadSceneAsync(2);
        operation.allowSceneActivation = true;
        while (!operation.isDone)
        {
            loadingBar.size = operation.progress;
            
            yield return null;
        }

    }
}
