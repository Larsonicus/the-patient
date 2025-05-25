using UnityEngine;
using System.Collections;

public class EnemyKill : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {  
            return;
        }

        other.GetComponent<PlayerDeathHandler>().Die();

        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }
}
