using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {

    private Vector3 dir;
    public GameObject gameOverCTS;

    public delegate void DarrenDetected(GameObject detector);
    public static event DarrenDetected OnDarrenDetected;

    private void OnTriggerStay(Collider other)
    {
        //if we hit the player...
        if (other.gameObject.CompareTag("Player"))
        {
            RaycastHit hit;
            dir = other.transform.position;
            //check if it's direct eye contact
            if (Physics.Linecast(transform.parent.position, other.transform.position,out hit))
            //if (Physics.Raycast(eyePos.position, transform.forward, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    if (OnDarrenDetected != null)
                        OnDarrenDetected(gameObject);
                    gameOverCTS.SetActive(true);
                    other.gameObject.SetActive(false);
                }
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.parent.position, dir);
    }
}
