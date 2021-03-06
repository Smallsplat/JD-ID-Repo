﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;

    Animator myAnim;
    float dist;

    Quaternion newRotation;
    float rotSpeed = 5f;

    RaycastHit hit;

    public bool isMoving = false;
    public bool pause = false;
    public GameObject HUDctrl;

    //Getting Animator
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        //Click to move
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                myAnim.SetBool("isRunning", true);
                isMoving = true;
            }
        }

        //Moving the player
        if (isMoving == true)
        {
            Vector3 relativePos = hit.point - transform.position;
            newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            newRotation.x = 0.0f;
            newRotation.z = 0.0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotSpeed * Time.deltaTime);

            HUDctrl.GetComponent<HUDController>().DecreaseCountSteps();

            dist = Vector3.Distance(hit.point, transform.position);
            if (dist < 0.5f)
            {
                myAnim.SetBool("isRunning", false);
                isMoving = false;
            }
        }
    }

    //Picking up items
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectables")
        {
            other.gameObject.SetActive(false);
            HUDctrl.GetComponent<HUDController>().IncrementCount();
        }

        if (other.gameObject.tag == "Locations")
        {
            other.gameObject.SetActive(false);
            HUDctrl.GetComponent<HUDController>().LocationPoints();
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == "Middle Of The Temple")
            {
                HUDctrl.GetComponent<HUDController>().MoveLocationMT();
            }
            if (other.gameObject.name == "Front of the temple")
            {
                HUDctrl.GetComponent<HUDController>().MoveLocationFT();
            }
            if (other.gameObject.name == "Hidden Alter")
            {
                HUDctrl.GetComponent<HUDController>().MoveLocationHA();
            }
            if (other.gameObject.name == "Right Shine")
            {
                HUDctrl.GetComponent<HUDController>().MoveLocationRS();
            }
            if (other.gameObject.name == "Left Shrine")
            {
                HUDctrl.GetComponent<HUDController>().MoveLocationLS();
            }

        }

        if (other.gameObject.tag == "Goat")
        {
            HUDctrl.GetComponent<HUDController>().GoatUI();
        }

        else
        {
            HUDctrl.GetComponent<HUDController>().HideGoatUI();
        }
    }
}
