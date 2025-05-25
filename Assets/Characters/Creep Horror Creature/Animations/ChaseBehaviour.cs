using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    private Transform player;
    NavMeshAgent agent;
    private float attackRange = 6;
    private float chaseRange = 20;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);

        if (distanceToPlayer < attackRange)
        {
            animator.SetBool("isAttacking", true);
        }

        if (distanceToPlayer > chaseRange)
        {
            animator.SetBool("isChasing", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
