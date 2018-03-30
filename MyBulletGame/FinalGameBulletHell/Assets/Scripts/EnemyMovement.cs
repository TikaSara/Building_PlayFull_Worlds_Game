using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform[] Waypoints;
	public float Speed;
	public int curWaypoint;
	public bool Patrol = true;
	public Vector3 Target;
	public Vector3 MoveDirection;
	public Vector3 Velocity;

	void Update()
	{
		// haalt een Waypoint op als er nog Waypoints over zijn
		if (curWaypoint < Waypoints.Length) 
		{
			// Reset de benodigde variabelen
			Target = Waypoints[curWaypoint].position;
			MoveDirection = Target - transform.position;
			Velocity = GetComponent<Rigidbody>().velocity;  
		
			// Als het object de waypoint gepasseert is
			if (MoveDirection.magnitude < 1) 
			{
				// Gaat naar het volgende waypoint
				curWaypoint++; 
			} 
            else 
            {
				// Houdt de snelheid consequent
				Velocity = MoveDirection.normalized * Speed;
			}
		} 
		else 
		{
			if (Patrol) 
			{
				// Gaat weer naar de eerste waypoint
				curWaypoint = 0; 
			} 
			else 
			{
				// Zet de snelheid naar 0
				Velocity = Vector3.zero; 
			}
		}

		// Past de berekende snelheid toe
		GetComponent<Rigidbody>().velocity = Velocity;
		transform.Rotate(new Vector3(0, 300, 0) * Time.deltaTime);
	}
}
