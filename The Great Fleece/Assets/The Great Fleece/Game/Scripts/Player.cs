using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour {

    public GameObject coin;
    public AudioClip coinSound;
    public LayerMask layerMask;
    public int coinsLeft;
    NavMeshAgent agent;
    Animator anim;
    Ray mouseToWorldRay;

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            mouseToWorldRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseToWorldRay, out hitInfo, Mathf.Infinity,layerMask))
            {
                agent.SetDestination(hitInfo.point);
                Debug.Log(hitInfo.point);
            }
        }

        if (Input.GetMouseButtonDown(1) && coinsLeft>0)
        {
            mouseToWorldRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseToWorldRay, out hitInfo, Mathf.Infinity, layerMask))
            {
                anim.SetTrigger("CoinToss");
                Instantiate(coin, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSound, coin.transform.position);
                coinsLeft--;          
            }
        }

        if (agent.remainingDistance > 0.1)
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);


	}
}
