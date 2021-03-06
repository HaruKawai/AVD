﻿// LocomotionSimpleAgent.cs
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class LocomotionSimpleAgent : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        // Don’t update position automatically
        agent.updatePosition = false;
    }

    void Update()
    {
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        anim.SetBool("move", shouldMove);
        anim.SetFloat("velx", velocity.x);
        anim.SetFloat("vely", velocity.y);

        //GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("disco trigger tag: "+ other.tag);
        if (other.CompareTag("Disco"))
        {
            velocity = Vector2.zero;
            anim.SetTrigger("dance");
            GetComponent<TimelineControl>().Play();
            other.GetComponentInParent<Animator>().SetTrigger("action");// in this case the animator is in the parent
        }
        else if (other.CompareTag("Flag"))
        {
            other.GetComponent<Animator>().SetBool("active", false);
        }
        else if (other.CompareTag("Chest"))
        {
            anim.SetTrigger("takeItem");
            other.GetComponent<Animator>().SetTrigger("Open");
            //GetComponent<TimelineControl>().PlayChest();
        }
    }
        void OnAnimatorMove()
        {
            // Update position to agent position
            transform.position = agent.nextPosition;


        }
    
}