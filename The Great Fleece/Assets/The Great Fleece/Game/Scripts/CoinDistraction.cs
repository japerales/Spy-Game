using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoinDistraction : MonoBehaviour {

    public float waitUntilDisableTrigger;
	// Use this for initialization
	void Start () {

        StartCoroutine("DisableTrigger");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guard1"))
        {
            GuardAction(other);
        }
    }

    IEnumerator DisableTrigger()
    {
        yield return new WaitForSeconds(waitUntilDisableTrigger);
        GetComponent<SphereCollider>().enabled = false;
    }

    void GuardAction(Collider guard)
    {
        NavMeshAgent nmAgent = guard.GetComponent<NavMeshAgent>();
        GuardAI guardAI = guard.GetComponent<GuardAI>();
        nmAgent.SetDestination(transform.position + Random.insideUnitSphere * 4);
        guardAI.CoinDetected = true;
    }
}
