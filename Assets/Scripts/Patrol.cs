using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

    private Transform playerInfield;

    private List<Transform> points = new List<Transform>();
	private int destPoint = 0;
	private NavMeshAgent agent;


	void Start ()
    {

		Transform[] targetArray = GameObject.FindGameObjectWithTag ("Target Array").GetComponentsInChildren<Transform>();
        playerInfield = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

		if (targetArray.Length == 0) 
		{
			print ("Didn't find the targets array");
		}

		foreach (Transform obj in targetArray) {
			
			points.Add(obj);
		}

		agent = GetComponent<NavMeshAgent>();


        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        agent.updateRotation = false;
        GotoNextPoint();

        InvokeRepeating("checkDistanceFromPlayer", 3f, 3f);


	}

    private void checkDistanceFromPlayer()
    {
        if (!playerInfield)
            return;
        if (Vector3.Distance(this.gameObject.transform.position, playerInfield.position)< 4)
        {
            GotoNextPoint();
        }
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        
        if (points.Count == 0)
			return;

		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = Random.Range(0,points.Count-1); 
	}

    
	void Update ()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
			GotoNextPoint();

	}
}
