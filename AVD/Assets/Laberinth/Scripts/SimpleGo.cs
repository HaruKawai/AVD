using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class SimpleGo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Destination;
    private Transform destination1;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination1 = Destination;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
