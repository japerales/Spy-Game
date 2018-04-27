using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(Animator))]
public class GuardAI : MonoBehaviour {


    public List<Transform> waypoints;
    Transform currentTarget;
    NavMeshAgent agent;
    Animator anim;
    int increment = 0;
    bool waitTime = false;
    public float minIdleTime;
    public float maxIdleTime;
    public bool CoinDetected;
    float IdleTimeTemp;
    bool Walk;
    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (waypoints != null && waypoints.Count > 0)
        {
            //lets set an initial random wait
            waitTime = Random.value > 0.5f;
            if (waitTime)
                IdleTimeTemp= Random.Range(minIdleTime, maxIdleTime);
            transform.position = waypoints[0].position;
        }   
    }
	
	// Update is called once per frame
	void Update () {

        //with this code we dont need to setDestination every frame
        if (waypoints.Count>0 && agent.remainingDistance < 0.05) {

            if (waitTime)
            {
                waitTime = IdleTimeTemp > 0f;
                IdleTimeTemp -= Time.deltaTime; 
            }
            else
            {
                int currentWaypoint = Mathf.FloorToInt(Mathf.PingPong(++increment, waypoints.Count - 1));
                currentTarget = waypoints[currentWaypoint];
                agent.SetDestination(currentTarget.position);
                //wait only in the first and last waypoints. In these waypoints also, we kept the autobraking, but in mid points we dont brake
                waitTime = agent.autoBraking = currentWaypoint == 0 || currentWaypoint == waypoints.Count - 1;
                IdleTimeTemp = Random.Range(minIdleTime, maxIdleTime); //random time between min and max
            }
        }
        //even if we call it every frame, we kept the animation logic separated from waypoint logic.
        Walk = agent.velocity.sqrMagnitude > 0.05f;
        anim.SetBool("Walk", Walk);

        if (CoinDetected)
        {
            CoinDetected = false;
            waitTime = true;
            agent.autoBraking = true;
        }

    }
}
