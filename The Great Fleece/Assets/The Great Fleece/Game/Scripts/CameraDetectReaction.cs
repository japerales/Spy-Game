using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetectReaction : MonoBehaviour {

    Animator anim;
    MeshRenderer mRenderer;

    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        anim = GetComponentInParent<Animator>();
    }

    private void OnEnable()
    {
        PlayerDetection.OnDarrenDetected += CameraDetectsPlayer;
    }

    private void OnDisable()
    {
        PlayerDetection.OnDarrenDetected -= CameraDetectsPlayer;
    }

    private void CameraDetectsPlayer(GameObject detector)
    {
        if (detector.Equals(gameObject))
        {
            //red color
            mRenderer.material.SetColor("_TintColor", new Color(1, 0, 0,0.1f));
            //camera stops.
            anim.speed = 0;
        }
    }
}
