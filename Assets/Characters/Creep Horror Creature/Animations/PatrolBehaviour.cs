using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    private float timer;
    List<Transform> patrolPoints = new List<Transform>();
    NavMeshAgent agent;

    private Transform player;
    private float chaseRange = 20;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;

        foreach (Transform point in pointsObject)
        {
            patrolPoints.Add(point);
        }

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoints[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Count)].position);
        }

        timer += Time.deltaTime;

        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }

        float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);
        if (distanceToPlayer < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
