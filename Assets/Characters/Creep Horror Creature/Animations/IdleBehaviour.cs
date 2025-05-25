using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    private float timer;
    
    Transform player;
    private float chaseRange = 20;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        
        if (timer > 5)
        {
            animator.SetBool("isPatrolling", true);
        }

        float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }
}
