using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GrabCardTrigger : MonoBehaviour {


    public GameObject CTS;
    PlayableDirector pd;
    public Transform previousPosition;

    private void Start()
    {
        pd = CTS.GetComponent<PlayableDirector>();
    }

    //this is used when scenes are triggered by colliders
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CTS.SetActive(true);
            pd.Play();
            //only disable the collider, we need the gameobject active due to the Update
            GetComponent<Collider>().enabled = false; //disable this collider so this way we dont repeat the cutscene.
            GameManager.Instance.HasCard = true;
        }
    }

    private void Update()
    {
        if (pd!=null && pd.state != PlayState.Playing)
        {
            pd.Stop();
            //restore the position of the camera before cutscene
            Camera.main.transform.localPosition = previousPosition.localPosition;
            Camera.main.transform.localRotation = previousPosition.localRotation;
            CTS.SetActive(false); //disable de cutscene
            gameObject.SetActive(false); //we must disable this object in order of
            //avoid calling this update again.
        }
    }



}
