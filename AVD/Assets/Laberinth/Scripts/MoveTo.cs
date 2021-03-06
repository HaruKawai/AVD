﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class MoveTo : MonoBehaviour
{   
    public NavMeshAgent agent;
    RaycastHit hitInfo = new RaycastHit();
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public Transform Flag;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                agent.destination = hitInfo.point;
                Flag.position = hitInfo.point;
                Flag.gameObject.GetComponent<Animator>().SetBool("active", true);
                
            }
        }
    }
}
