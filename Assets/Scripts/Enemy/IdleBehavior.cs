using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    Transform player;
    float timer ;
    public float waitTime = 2;
    public float detectDistance = 4;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Execute();
        CheckTriggers(animator);

    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayer = isPlayerClose(player, animator.transform);
        animator.SetBool("IsChasing", isPlayer);

        bool timeUp = isTimeUp();
        animator.SetBool("IsPatrolling", timeUp);
    }
    private void Execute()
    {
        timer += Time.deltaTime;
    }


    public bool isPlayerClose(Transform player, Transform enemy)
    {
        
        return Vector3.Distance(player.position, enemy.position) < detectDistance;
    }
    public bool isTimeUp()
    {
        return timer > waitTime;
    }
}
