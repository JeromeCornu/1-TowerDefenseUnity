using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    private Transform goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal").GetComponent<Transform>();

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
