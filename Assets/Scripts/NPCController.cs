using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCController : MonoBehaviour
{
    public float patrolTime = 5f;
    public float agroRange = 10f;
    public Transform[] waypoints;

    private int index;
    private float speed, agentSpeed;
    Transform player;
    Animator animator;
    private NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent != null) {agentSpeed = agent.speed;}

        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0, waypoints.Length); //start at random point

        InvokeRepeating("Tick", 0, 0.5f);


        if (waypoints.Length > 1)
        {
            InvokeRepeating("Patrol", 0, patrolTime);
        }
    }
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Patrol()
    {
        index = index == waypoints.Length -1 ? 0 : index +1;
    }
    void Tick()
    {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed / 2;

        if(player != null && Vector3.Distance(player.position, transform.position) < agroRange)
        {
            agent.destination = player.position;
            agent.speed = agentSpeed;
        }
    }
}
