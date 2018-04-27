using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IntroController : MonoBehaviour {

    PlayableDirector pd;
    public Transform previousPosition;
    bool Skiped;

    private void Start()
    {
        pd = GetComponent<PlayableDirector>();
    }
	// Update is called once per frame
	void Update () {
        if (pd != null && pd.state != PlayState.Playing)
        {
            pd.Stop();
            //restore the position of the camera before cutscene
            Camera.main.transform.localPosition = previousPosition.localPosition;
            Camera.main.transform.localRotation = previousPosition.localRotation;
            gameObject.SetActive(false); //we must disable this object in order of
            //avoid calling this update again. This component also must be attached
        }

        //not the best way, but the fastest for this demo
        //we should have a timeline manager, and custom timeline script with skipable behaviours.
        if (Input.GetKeyDown("s") && !Skiped)
        {
            Skiped = true;
            pd.time = 60.2f;
        }
    }
}
