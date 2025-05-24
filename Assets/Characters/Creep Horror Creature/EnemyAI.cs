using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 15f;
    public float attackRange = 2f;

    private NavMeshAgent agent;
    private Transform player;
    private Animator animator;

    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(player.position);

            if (distance <= attackRange)
            {
                agent.isStopped = true;

                if (!isAttacking)
                {
                    isAttacking = true;
                    animator.SetTrigger("Attack");
                }
            }
            else
            {
                isAttacking = false;
                agent.isStopped = false;
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            isAttacking = false;
            agent.isStopped = true;
            animator.SetBool("IsWalking", false);
        }
    }
}
