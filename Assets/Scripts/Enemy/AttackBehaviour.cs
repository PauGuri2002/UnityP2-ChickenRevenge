using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    //public float speed = 5f;
    //private Vector3 goTo;
    [SerializeField]
    [Range(0f, 10f)]
    public float detectDistance = 7f;
    private AttackDetectionScript script;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        script = animator.GetComponent<AttackDetectionScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // SetDirection(animator);
        Execute(animator);
        CheckTriggers(animator);

    }
    private void Execute(Animator animator)
    {
        if (animator.GetBool("IsChasing"))
        {
            script.enabled = true;
        }
        else
        {
            script.enabled = false;
        }

    }
    

    private void CheckTriggers(Animator animator)
    {
        bool isPlayer = isPlayerClose(player, animator.transform);
        animator.SetBool("IsChasing", isPlayer);
        animator.SetBool("IsPatrolling", !isPlayer);
    }
    public bool isPlayerClose(Transform player, Transform enemy)
    {

        return Vector3.Distance(player.position, enemy.position) < detectDistance;
    }
    

   
}
