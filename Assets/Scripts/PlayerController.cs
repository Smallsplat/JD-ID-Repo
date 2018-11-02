﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
	public Camera camera;
	public NavMeshAgent agent;

	Animator myAnim;
	float dist;

	Quaternion newRotation;
	float rotSpeed = 5f;

	RaycastHit hit;

	public bool isMoving = false;

	void Start () 
	{
		myAnim = GetComponent<Animator> ();
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0)) 
		{
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) 
			{
				agent.SetDestination (hit.point);
				myAnim.SetBool ("isRunning", true);
				isMoving = true;
			}
		}

		if (isMoving == true) 
		{
			Vector3 relativePos = hit.point - transform.position;
			newRotation = Quaternion.LookRotation (relativePos, Vector3.up);
			newRotation.x = 0.0f;
			newRotation.z = 0.0f;

			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotSpeed * Time.deltaTime);

			dist = Vector3.Distance (hit.point, transform.position);
			if (dist < 0.5f) 
			{
				myAnim.SetBool ("isRunning", false);
				isMoving = false;
			}
		}
	}
}
